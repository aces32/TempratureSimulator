using Microsoft.AspNetCore.SignalR;

namespace IoTBackend
{
    public class TemperatureHub : Hub
    {
        public async Task SendTemperature(string deviceId, double temperature, DateTime timestamp)
        {
            await Clients.All.SendAsync("ReceiveTemperature", deviceId, temperature, timestamp);
        }
    }

}
