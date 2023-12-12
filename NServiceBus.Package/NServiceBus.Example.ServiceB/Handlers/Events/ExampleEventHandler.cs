using Shared.Events;

namespace NServiceBus.Example.ServiceB.Handlers.Events
{
    public class ExampleEventHandler : IHandleMessages<ExampleEvent>
    {
        public Task Handle(ExampleEvent message, IMessageHandlerContext context)
        {
            Console.WriteLine($"{message.Message}");
            return Task.CompletedTask;
        }
    }
}
