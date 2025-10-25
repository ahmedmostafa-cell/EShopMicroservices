namespace Shpooing.Web.Models.Ordering;

public class OrderItemModel
{
	public Guid OrderId { get;  set; } = default!;
	public Guid ProductId { get;  set; } = default!;
	public int Quantity { get;  set; } = default!;
	public decimal Price { get;  set; } = default!;
}
