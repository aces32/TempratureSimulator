using System.Text;
using TemperatureDashboard.Models;

namespace TemperatureDashboard
{
    public static partial class OllamaAnalyse
    {
        public static async Task<string> AnalyzeTemperatureDataAsync(this List<TemperatureReading> readings)
        {
            var ollamaPrompt = new StringBuilder();
            ollamaPrompt.AppendLine("You are a data analyst for ATS Life Sciences Europe. Respond clearly and concisely when analyzing data.:");
            ollamaPrompt.AppendLine("Analyze the following temperature readings and highlight trends or anomalies:");
            ollamaPrompt.AppendLine("DeviceId,Temperature,Timestamp");

            foreach (var r in readings)
            {
                ollamaPrompt.AppendLine($"{r.DeviceId},{r.Temperature},{r.Timestamp.ToLocalTime():yyyy-MM-dd HH:mm:ss}");
            }

            using var client = new HttpClient();
            var content = new
            {
                model = "llama3",
                prompt = ollamaPrompt.ToString(),
                stream = false
            };

            var response = await client.PostAsJsonAsync("http://localhost:11434/api/generate", content);
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result?.response ?? "No response from Ollama";
        }

    }
}
