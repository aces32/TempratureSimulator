using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.AspNetCore.Hosting.Server;

namespace TemperatureDashboard.Models
{

    public class TemperatureSeries
    {
        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }

        public TemperatureSeries()
        {
            Series = new ISeries[]
            {
            new LineSeries<double>
            {
                Values = new List<double>(),
                Fill = null
            }
            };

            XAxes = new Axis[]
            {
            new Axis
            {
                Labels = new List<string>(),
                LabelsRotation = 15
            }
            };

            YAxes = new Axis[]
            {
            new Axis { Name = "Temperature (°C)" }
            };
        }
    }

}
