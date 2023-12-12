using Shared.Messages;

namespace NServiceBus.Example.ServiceB.Handlers.Messages
{
    public class ExampleMessageHandler : IHandleMessages<ExampleMessage>
    {
        public Task Handle(ExampleMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received message : {message.Message}");
            return Task.CompletedTask;
        }
    }
}
