namespace MqttReceiver.Models
{
    public class TemperatureReading
    {
        public required string DeviceId { get; set; }
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
