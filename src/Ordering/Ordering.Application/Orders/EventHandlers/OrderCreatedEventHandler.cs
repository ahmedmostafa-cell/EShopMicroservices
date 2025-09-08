namespace Ordering.Application.Orders.EventHandlers;

public class OrderCreatedEventHandler(
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreateEvent>
{
    public Task Handle(OrderCreateEvent notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "dOMAIN eVENT hANDLED: {Domain Event}", 
            notification.GetType().Name);

        return Task.CompletedTask;
    }
}
