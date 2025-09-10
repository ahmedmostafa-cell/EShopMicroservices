namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext dbContext)
	: IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
	public async Task<GetOrdersResult> Handle
		(GetOrdersQuery query,
		CancellationToken cancellationToken)
	{
		var pageIndex = query.PaginationRequest.pageIndex;

		var pageSize = query.PaginationRequest.pageSize;

		var count = await dbContext.Orders.LongCountAsync(cancellationToken);

		var orders = await dbContext.Orders
			.Include(a => a.Items)
			.Skip(pageIndex*pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		return new GetOrdersResult(
			new PaginatedResult<OrderDto>(
				pageIndex, 
				pageSize, 
				count, 
				orders.ToOrderDtosList()));
	}

}