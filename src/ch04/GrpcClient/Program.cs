// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;

using GrpcServer;

Console.WriteLine("Hello, gRPC World!");

var url = "https://localhost:7294";
var channel = GrpcChannel.ForAddress(url);
var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(new HelloRequest { Name = "World" });
Console.WriteLine("Greeting: " + response.Message);

var calcClient = new Calc.CalcClient(channel);
var calcResponse = await calcClient.AddAsync( new CalcRequest {  X = 10, Y = 20 });
Console.WriteLine($"ans: {calcResponse.Ans}");
