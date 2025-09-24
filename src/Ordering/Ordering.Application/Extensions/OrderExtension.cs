namespace Ordering.Application.Extensions;
public static class OrderExtension
{
	public static IEnumerable<OrderDto> ToOrderDtosList(this List<Order> orders)
	{
		return orders.Select(order => new OrderDto(
			Id: order.Id.Value,
			CustomerId: order.CustomerId.Value,
			OrderName: order.OrderName.Value,
			ShippingAddress: new AddressDto(
				order.ShippingAddress.FirstName,
				order.ShippingAddress.LastName,
				order.ShippingAddress.EmailAddress,
				order.ShippingAddress.AddressLine,
				order.ShippingAddress.Country,
				order.ShippingAddress.State,
				order.ShippingAddress.ZipCode),
			BillingAddress: new AddressDto(
				order.ShippingAddress.FirstName,
				order.ShippingAddress.LastName,
				order.ShippingAddress.EmailAddress,
				order.ShippingAddress.AddressLine,
				order.ShippingAddress.Country,
				order.ShippingAddress.State,
				order.ShippingAddress.ZipCode),
			Payment: new PaymentDto(
				order.Payment.CardName,
				order.Payment.CardNumber,
				order.Payment.Expiration,
				order.Payment.CVV,
				order.Payment.PaymentMethod),
			Status: order.Status,
			OrderItems: order.Items.Select(item => new OrderItemDto(
				item.OrderId.Value,
				item.ProductID.Value,
				item.Quantity,
				item.Price))
			.ToList()));
	}

	public static OrderDto ToOrderDto(this Order order)
	{
		return new OrderDto(
			Id: order.Id.Value,
			CustomerId: order.CustomerId.Value,
			OrderName: order.OrderName.Value,
			ShippingAddress: new AddressDto(
				order.ShippingAddress.FirstName,
				order.ShippingAddress.LastName,
				order.ShippingAddress.EmailAddress,
				order.ShippingAddress.AddressLine,
				order.ShippingAddress.Country,
				order.ShippingAddress.State,
				order.ShippingAddress.ZipCode),
			BillingAddress: new AddressDto(
				order.ShippingAddress.FirstName,
				order.ShippingAddress.LastName,
				order.ShippingAddress.EmailAddress,
				order.ShippingAddress.AddressLine,
				order.ShippingAddress.Country,
				order.ShippingAddress.State,
				order.ShippingAddress.ZipCode),
			Payment: new PaymentDto(
				order.Payment.CardName,
				order.Payment.CardNumber,
				order.Payment.Expiration,
				order.Payment.CVV,
				order.Payment.PaymentMethod),
			Status: order.Status,
			OrderItems: order.Items.Select(item => new OrderItemDto(
				item.OrderId.Value,
				item.ProductID.Value,
				item.Quantity,
				item.Price)
			).ToList()
		);
	}
}
