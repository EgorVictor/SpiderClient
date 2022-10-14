// See https://aka.ms/new-console-template for more information

using Spider;

var entity = await SpiderClient.RunAsync<Entity>();
Console.ReadKey();