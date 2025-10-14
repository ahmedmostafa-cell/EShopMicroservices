namespace Shpooing.Web.Models.Ordering;

public class OrderModel
{
	public Guid Id { get; private set; } = default!;
	public Guid CustomerId { get; private set; } = default!;
	public string OrderName { get; private set; } = default!;
	public AddressModel ShippingAddress { get; private set; } = default!;
	public AddressModel BillingAddress { get; private set; } = default!;
	public PaymentModel Payment { get; private set; } = default!;
	public OrderStatus Status { get; private set; } = default!;
	public List<OrderItemModel> OrderItems { get; private set; } = default!;
}

public enum OrderStatus
{
	Draft = 1,
	Pending = 2,
	Completed = 3,
	Cancelled = 4,
}

public class PaginatedResult<TEntity>(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
where TEntity : class

{
	public int PageIndex { get; } = pageIndex;
	public int PageSize { get; } = pageSize;
	public long Count { get; } = count;
	public IEnumerable<TEntity> Data { get; } = data;

}

public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);

public record GetOrderByCustomerResponse(IEnumerable<OrderModel> Orders);

public record GetOrderByNameResponse(IEnumerable<OrderModel> Orders);



