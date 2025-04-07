using TempratureSimulator.Contracts;

namespace TempratureSimulator.Services
{
    public class RandomTemperatureSensor : ITemperatureSensor
    {
        private readonly Random _random = new Random();

        public double GetTemperature()
        {
            return Math.Round(20 + _random.NextDouble() * 15, 2);
        }
    }
}
