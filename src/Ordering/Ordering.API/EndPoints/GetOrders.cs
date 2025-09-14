namespace Ordering.API.EndPoints;

//public record GetOrdersRequest(PaginationRequest PaginationRequest);

public record GetOrdersResponse(PaginatedResult<OrderDto> orders);

public class GetOrders : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders", async ([AsParameters]PaginationRequest PaginationRequest, ISender sender) =>
		{
			var result = await sender.Send(new GetOrdersQuery(PaginationRequest));
			var response = result.Adapt<GetOrdersResponse>();
			return Results.Ok(response);
		})
	   .WithName("GetOrders")
	   .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
	   .ProducesProblem(StatusCodes.Status400BadRequest)
	   .ProducesProblem(StatusCodes.Status404NotFound)
	   .WithSummary("Get Orders")
	   .WithDescription("Get Orders");
	}
}
