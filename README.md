# 🌡️ Temperature Simulator Solution

This project simulates IoT-based temperature monitoring with a real-time dashboard and backend communication via MQTT.

## 🧩 Solution Structure

- **IoTBackend**: Receives and processes temperature data, potentially storing it in a database or exposing APIs.
- **MqttReceiver**: A service that listens to MQTT messages and routes them to the backend.
- **TemperatureDashboard**: A web interface (possibly with SignalR or WebSocket) to display real-time temperature updates.
- **TempratureSimulator**: Simulates sensor data and publishes it to MQTT topics.

## 🚀 Getting Started
## .NET Components

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/TemperatureSimulator.git
   cd TemperatureSimulator
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run the simulator and receiver first:
   ```bash
   dotnet run --project TempratureSimulator
   dotnet run --project MqttReceiver
   ```

5. Start the backend and dashboard:
   ```bash
   dotnet run --project IoTBackend
   dotnet run --project TemperatureDashboard
   ```
## Python Component   
6. Set up the Python environment for SensorDataLogger:
   ```bash
	cd SensorDataLogger
	python -m venv venv
	source venv/bin/activate  # or venv\Scripts\activate on Windows
	pip install -r requirements.txt
   ```
5. Run the logger:
   ```bash
   python main.py
   ```   

> ⚠️ Make sure you have an MQTT broker running (e.g., Mosquitto on localhost) before launching the services.

## ⚙️ Tech Stack

- C# / .NET
- MQTT
- ASP.NET Core
- SignalR 
- Ollama / LLM
- Docker (optional)

## 📦 Future Improvements

- Add authentication and authorization
- Persist data to PostgreSQL or InfluxDB
- Deploy with Docker Compose

## 📄 License

MIT License
