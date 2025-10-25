namespace Shpooing.Web.Models.Ordering;

public class OrderModel
{
	public Guid Id { get;  set; } = default!;
	public Guid CustomerId { get;  set; } = default!;
	public string OrderName { get;  set; } = default!;
	public AddressModel ShippingAddress { get;  set; } = default!;
	public AddressModel BillingAddress { get;  set; } = default!;
	public PaymentModel Payment { get;  set; } = default!;
	public OrderStatus Status { get;  set; } = default!;
	public List<OrderItemModel> OrderItems { get;  set; } = default!;
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



