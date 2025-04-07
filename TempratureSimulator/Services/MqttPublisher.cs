using MQTTnet;
using System.Text.Json;
using TempratureSimulator.Contracts;
using TempratureSimulator.Models;

namespace TempratureSimulator.Services
{
    public class MqttPublisher : IMqttPublisher
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientOptions _options;
        private const string Topic = "iot/temperature";

        public MqttPublisher(string brokerAddress, string clientId)
        {
            var factory = new MqttClientFactory();
            _mqttClient = factory.CreateMqttClient();

            _options = new MqttClientOptionsBuilder()
                .WithClientId("sensor-001")
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithCleanSession()
                .Build();
        }

        public async Task PublishAsync(TemperatureReading reading)
        {
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_options, CancellationToken.None);
            }

            var json = JsonSerializer.Serialize(reading);

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(Topic)
                .WithPayload(json)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await _mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
