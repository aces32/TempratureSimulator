#!/bin/bash
# Run all projects in the TemperatureSimulator solution in the correct order

echo "Starting MqttReceiver..."
dotnet run --project MqttReceiver/MqttReceiver.csproj &
MQTT_PID=$!

# Wait a few seconds for MqttReceiver to initialize (adjust as needed)
sleep 3

echo "Starting IoTBackend..."
dotnet run --project IoTBackend/IoTBackend.csproj &
BACKEND_PID=$!

echo "Starting TemperatureDashboard..."
dotnet run --project TemperatureDashboard/TemperatureDashboard.csproj &
DASHBOARD_PID=$!

echo "Starting TempratureSimulator..."
dotnet run --project TempratureSimulator/TempratureSimulator.csproj &
SIMULATOR_PID=$!

echo "All projects are running."
echo "Press Ctrl+C to stop."

# Wait for all processes to end
wait $MQTT_PID $BACKEND_PID $DASHBOARD_PID $SIMULATOR_PID
