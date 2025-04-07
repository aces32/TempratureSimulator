using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace IoTBackend.Controllers
{
    [ApiController]
    [Route("api/temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly IHubContext<TemperatureHub> _hubContext;

        public TemperatureController(IHubContext<TemperatureHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TemperatureReading reading)
        {
            // Broadcast to all connected SignalR clients
            await _hubContext.Clients.All.SendAsync("ReceiveTemperature", reading.DeviceId, reading.Temperature, reading.Timestamp);

            return Ok();
        }
    }

}
