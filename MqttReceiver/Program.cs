// See https://aka.ms/new-console-template for more information
using MqttReceiver.Services;

Console.WriteLine("Hello, World!");
var receiver = new MqttReceivers();
Console.WriteLine("Starting MQTT Receiver...");
await receiver.StartAsync();
Console.WriteLine("Press Ctrl+C to exit.");
await Task.Delay(-1);