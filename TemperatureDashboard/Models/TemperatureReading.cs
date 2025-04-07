namespace TemperatureDashboard.Models
{
    public class TemperatureReading
    {
        public string DeviceId { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString() =>
            $"{DeviceId} | {Temperature}°C | {Timestamp:g}";
    }
}
