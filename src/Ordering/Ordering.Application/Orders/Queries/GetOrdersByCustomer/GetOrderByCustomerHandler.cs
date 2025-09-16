namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;
public class GetOrderByCustomerHandler(IApplicationDbContext dbContext)
	: IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
{
	public async Task<GetOrderByCustomerResult> Handle
		(GetOrderByCustomerQuery query,
		CancellationToken cancellationToken)
	{
		var orders = await dbContext.Orders
			.Include(a => a.Items)
			.AsNoTracking()
			.Where(a => a.CustomerId == CustomerId.Of(query.Customer.Value))
			.OrderBy(a => a.OrderName.Value)
			.ToListAsync(cancellationToken);

		return new GetOrderByCustomerResult(orders.ToOrderDtosList());
	}

}