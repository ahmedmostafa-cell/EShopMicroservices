namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
	: IConsumer<BasketCheckoutEvent>
{
	public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
	{
		logger.LogInformation("Integration event handler : {IntegrationEvent}", context.GetType().Name);
		var command = MapToCreateOrderCommand(context.Message);
		await sender.Send(command);
	}

	private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
	{
		var addressDTO = new AddressDto(
			message.FirstName,
			message.LastName,
			message.EmailAddress,
			message.AddressLine,
			message.Country,
			message.State,
			message.ZipCode);

		var orderID = Guid.NewGuid();

		var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);

		var newOrder = new OrderDto(
			Id: orderID,
			CustomerId: message.CustomerId,
			OrderName: message.UserName,
			ShippingAddress: addressDTO,
			BillingAddress: addressDTO,
			Payment: paymentDto,
			Status: Ordering.Domain.Enums.OrderStatus.Pending,
			OrderItems: [
				new OrderItemDto(orderID, new Guid("3c4a76aa-5f3f-4e0f-9b7d-6e8c17d5c39e"),2,650),
				new OrderItemDto(orderID, new Guid("91de0cf6-6d62-4c70-87f2-760a268d3571"), 1, 450),
			]
		);

		return new CreateOrderCommand(newOrder);
	}
}
