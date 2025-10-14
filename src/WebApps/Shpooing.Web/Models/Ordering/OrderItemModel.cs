namespace Shpooing.Web.Models.Ordering;

public class OrderItemModel
{
	public Guid OrderId { get; private set; } = default!;
	public Guid ProductId { get; private set; } = default!;
	public int Quantity { get; private set; } = default!;
	public decimal Price { get; private set; } = default!;
}
