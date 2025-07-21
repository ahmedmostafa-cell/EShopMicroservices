namespace Ordering.Domain.Models;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; } = default!;
    public string ProductID { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    internal OrderItem(Guid orderId, string productID, decimal price, int quantity)
    {
        OrderId = orderId;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }
}

