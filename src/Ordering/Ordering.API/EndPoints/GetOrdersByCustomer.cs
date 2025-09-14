namespace Ordering.API.EndPoints;

//public record GetOrderByCustomerRequest(Guid customerID);

public record GetOrderByCustomerResponse(IEnumerable<OrderDto> orders);

public class GetOrdersByCustomer : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders/customer/{customerID}", async (Guid customerID, ISender sender) =>
		{
			var result = await sender.Send(new GetOrderByCustomerQuery(CustomerId.Of(customerID)));
			var response = result.Adapt<GetOrderByCustomerResponse>();
			return Results.Ok(response);
		})
	   .WithName("GetOrdersByCustomer")
	   .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
	   .ProducesProblem(StatusCodes.Status400BadRequest)
	   .ProducesProblem(StatusCodes.Status404NotFound)
	   .WithSummary("Get Order By Customer")
	   .WithDescription("Get Order By Customer");
	}
}
