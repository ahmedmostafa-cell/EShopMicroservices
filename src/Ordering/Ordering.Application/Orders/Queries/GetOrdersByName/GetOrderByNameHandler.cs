namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrderByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle
        (GetOrderByNameQuery query,
        CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(a=> a.Items)
            .AsNoTracking()
            .Where(a=> a.OrderName.Value.Contains(query.Name))
            .OrderBy(a=> a.OrderName)
            .ToListAsync(cancellationToken);

        var ordersDto =ProjectToOrderDto(orders);

        return new GetOrderByNameResult(ordersDto);
    }
    private  List<OrderDto> ProjectToOrderDto(List<Order> orders)
    {
        List<OrderDto> result = new();
        foreach (var order in orders) 
        {
            OrderDto orderDto = new(
                Id :order.Id.Value,
                CustomerId : order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress : new AddressDto(
                    order.ShippingAddress.FirstName, 
                    order.ShippingAddress.LastName, 
                    order.ShippingAddress.EmailAddress, 
                    order.ShippingAddress.AddressLine , 
                    order.ShippingAddress.Country , 
                    order.ShippingAddress.State , 
                    order.ShippingAddress.ZipCode),
                BillingAddress: new AddressDto(
                    order.ShippingAddress.FirstName, 
                    order.ShippingAddress.LastName, 
                    order.ShippingAddress.EmailAddress, 
                    order.ShippingAddress.AddressLine, 
                    order.ShippingAddress.Country, 
                    order.ShippingAddress.State, 
                    order.ShippingAddress.ZipCode),
                Payment:new PaymentDto(
                    order.Payment.CardName, 
                    order.Payment.CardNumber, 
                    order.Payment.Expiration , 
                    order.Payment.CVV , 
                    order.Payment.PaymentMethod),
                Status:order.Status,
                OrderItems:order.Items.Select(item => new OrderItemDto(
                    item.OrderId.Value , 
                    item.ProductID.Value, 
                    item.Quantity , 
                    item.Price)).ToList()
            );

            result.Add(orderDto);
        }

        return result;
    }
}
