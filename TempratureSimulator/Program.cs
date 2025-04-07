// See https://aka.ms/new-console-template for more information
using TempratureSimulator.Models;
using TempratureSimulator.Services;

Console.WriteLine("Starting SOLID-based MQTT Temperature Simulator...");

var sensor = new RandomTemperatureSensor();
var publisher = new MqttPublisher("test.mosquitto.org", "sensor-001");

try
{
    while (true)
    {
        var reading = new TemperatureReading
        {
            DeviceId = "sensor-001",
            Temperature = sensor.GetTemperature(),
            Timestamp = DateTime.UtcNow
        };

        await publisher.PublishAsync(reading);
        Console.WriteLine($"Published: {reading.Temperature}°C at {reading.Timestamp}");

        await Task.Delay(5000);
    }
}
catch (Exception ex)
{
    Console.WriteLine( ex.Message);

}

