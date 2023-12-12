using Shared;

EndpointConfiguration endpointConfiguration = new(ServiceRegistryInformations.ServiceCEndpointName);
var rabbitMQTransport = endpointConfiguration.UseTransport<RabbitMQTransport>();
rabbitMQTransport.ConnectionString("...");
rabbitMQTransport.UseConventionalRoutingTopology(QueueType.Quorum);

endpointConfiguration.EnableInstallers();

IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration);

//await endpointInstance.Stop();
Console.Read();