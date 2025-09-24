namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint,
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreateEvent>
{
    public async Task Handle(OrderCreateEvent domainEvent,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event Handled: {Domain Event}",domainEvent.GetType().Name);

        var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();

        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}
