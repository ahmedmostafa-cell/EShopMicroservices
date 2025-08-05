using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public CustomerId CustomerId { get; private set; } = default!;
    public OrderName OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice 
    {
        get => _items.Sum(item => item.Price * item.Quantity);
        private set { } 
    }

	public static Order Create(OrderId id, CustomerId customerId, OrderName orderName , 
        Address shippingAddress , Address billingAddress , Payment payment)
	{
        var order = new Order
        {
            Id = id,
			CustomerId = customerId,
			OrderName = orderName,
			ShippingAddress = shippingAddress,
			BillingAddress = billingAddress,
			Payment = payment,
		};

        order.AddDomainEvent(new OrderCreateEvent(order));

        return order;
	}

    public void Update(OrderName orderName,
		Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status) 
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
		Status = status;

		AddDomainEvent(new OrderUpdatedEvent(this));
	}

    public void Add(ProductID productID, decimal price, int quantity) 
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

		var orderItem = new OrderItem(Id,productID, price, quantity);

        _items.Add(orderItem);
	}

    public void Remove(ProductID productId) 
    {
        var orderItem = _items.FirstOrDefault(a => a.ProductID == productId);
        if(orderItem is not null) 
        {
			_items.Remove(orderItem);
		}

	}

}
