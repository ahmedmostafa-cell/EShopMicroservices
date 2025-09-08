namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrderByNameQuery(string Name)
    : IQuery<GetOrderByNameResult>;

public record GetOrderByNameResult(IEnumerable<OrderDto> orders);