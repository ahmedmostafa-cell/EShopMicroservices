namespace Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    public OrderId OrderId { get; private set; } = default!;
    public ProductID ProductID { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    internal OrderItem(OrderId orderId, ProductID productID, decimal price, int quantity)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }
}

