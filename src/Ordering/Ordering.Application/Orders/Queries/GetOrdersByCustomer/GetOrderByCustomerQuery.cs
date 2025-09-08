namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrderByCustomerQuery(CustomerId Customer)
	: IQuery<GetOrderByCustomerResult>;

public record GetOrderByCustomerResult(IEnumerable<OrderDto> orders);
