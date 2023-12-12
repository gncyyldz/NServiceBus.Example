using Shared;
using Shared.Events;
using Shared.Messages;

EndpointConfiguration endpointConfiguration = new(ServiceRegistryInformations.ServiceAEndpointName);
var rabbitMQTransport = endpointConfiguration.UseTransport<RabbitMQTransport>();
rabbitMQTransport.ConnectionString("...");
rabbitMQTransport.UseConventionalRoutingTopology(QueueType.Quorum);

endpointConfiguration.EnableInstallers();

IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration);

while (true)
{
    Console.WriteLine("Mesajı yazınız...");

    #region Hedef Endpoint'e Mesaj Gönderme
    ExampleMessage message = new() { Message = Console.ReadLine() };
    await endpointInstance.Send(ServiceRegistryInformations.ServiceCEndpointName, message);
    #endregion

    #region Tüm Endpoint'lere Event Yayınlama
    ExampleEvent @event = new() { Message = "...Event content..." };
    await endpointInstance.Publish(@event);
    #endregion


    Console.WriteLine("Devam mı? D/H");
    if (Console.ReadKey().Key == ConsoleKey.H)
        break;
}

await endpointInstance.Stop();
Console.Read();