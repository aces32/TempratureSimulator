using TempratureSimulator.Models;

namespace TempratureSimulator.Contracts
{
    public interface IMqttPublisher
    {
        Task PublishAsync(TemperatureReading reading);
    }
}
