using NServiceBus;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNServiceBus(context =>
{
    EndpointConfiguration endpointConfiguration = new(ServiceRegistryInformations.WebAPIBEndpointName);
    var rabbitMQTransport = endpointConfiguration.UseTransport<RabbitMQTransport>();
    rabbitMQTransport.ConnectionString(builder.Configuration.GetConnectionString("RabbitMQ"));
    rabbitMQTransport.UseConventionalRoutingTopology(QueueType.Quorum);

    endpointConfiguration.EnableInstallers();
    return endpointConfiguration;
});

var app = builder.Build();

app.Run();
