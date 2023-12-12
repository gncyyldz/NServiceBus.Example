using NServiceBus;
using Shared;
using Shared.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseNServiceBus(context =>
{
    EndpointConfiguration endpointConfiguration = new(ServiceRegistryInformations.WebAPIAEndpointName);
    var rabbitMQTransport = endpointConfiguration.UseTransport<RabbitMQTransport>();
    rabbitMQTransport.ConnectionString(builder.Configuration.GetConnectionString("RabbitMQ"));
    rabbitMQTransport.UseConventionalRoutingTopology(QueueType.Quorum);

    endpointConfiguration.EnableInstallers();
    return endpointConfiguration;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/send-message", async (IMessageSession messageSession) =>
{
    ExampleMessage exampleMessage = new() { Message = "Example message" };
    await messageSession.Send(ServiceRegistryInformations.WebAPIBEndpointName, exampleMessage);

    return TypedResults.Ok();
});

app.Run();
