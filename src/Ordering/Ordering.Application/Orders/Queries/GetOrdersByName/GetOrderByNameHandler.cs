using Ordering.Application.Extensions;

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

        return new GetOrderByNameResult(orders.ToOrderDtosList());
    }
    
}
