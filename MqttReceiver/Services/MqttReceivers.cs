using MQTTnet;
using MQTTnet.Protocol;
using MqttReceiver.Contracts;
using MqttReceiver.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MqttReceiver.Services
{
    public class MqttReceivers : IMqttReceiver
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientOptions _options;
        private readonly HttpClient _httpClient = new HttpClient();

        public MqttReceivers()
        {
            var factory = new MqttClientFactory();
            _mqttClient = factory.CreateMqttClient();

            _options = new MqttClientOptionsBuilder()
                .WithClientId("receiver-001")
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithCleanSession()
                .Build();

            _mqttClient.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected to MQTT broker.");

                await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic("iot/temperature")
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build());

                Console.WriteLine("Subscribed to topic: iot/temperature");
            };

            _mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                try
                {
                    var reading = JsonSerializer.Deserialize<TemperatureReading>(payload);
                    var response = await _httpClient.PostAsJsonAsync("http://localhost:5177/api/temperature", reading);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("❌ Failed to push data to SignalR API");
                    }

                    Console.WriteLine($"Received → Device: {reading?.DeviceId}, Temp: {reading?.Temperature}°C, Time: {reading?.Timestamp}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to parse message: {payload}. Error: {ex.Message}");
                }

                await Task.CompletedTask;
            };

        }

        public async Task StartAsync()
        {
            try
            {
                await _mqttClient.ConnectAsync(_options, CancellationToken.None);
                if (_mqttClient.IsConnected)
                {
                    Console.WriteLine("✅ MQTT client connected successfully.");
                }
                else
                {
                    Console.WriteLine("❌ MQTT client failed to connect. Check broker settings or network connectivity.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to MQTT broker. {ex}");

            }

        }
    }

}
