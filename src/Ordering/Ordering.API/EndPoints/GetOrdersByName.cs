
namespace Ordering.API.EndPoints;


//public record GetOrderByRequest(string Name);

public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
		{
			var result = await sender.Send(new GetOrderByNameQuery(orderName));
			var response = result.Adapt<GetOrderByNameResponse>();
			return Results.Ok(response);
		})
	   .WithName("GetOrdersByName")
	   .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
	   .ProducesProblem(StatusCodes.Status400BadRequest)
	   .ProducesProblem(StatusCodes.Status404NotFound)
	   .WithSummary("Get Order By Name")
	   .WithDescription("Get Order By Name");
	}
}
