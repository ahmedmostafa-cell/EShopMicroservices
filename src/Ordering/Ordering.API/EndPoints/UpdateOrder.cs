namespace Ordering.API.EndPoints;

public record UpdateOrderRequest(OrderDto OrderDto);
public record UpdateOrderResponse(bool IsSuccess);
public class UpdateOrder : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
		{
			var command = request.Adapt<UpdateOrderCommand>();
			var result = await sender.Send(command);
			var response = result.Adapt<UpdateOrderResponse>();
			return Results.Ok(response);
		})
		  .WithName("UpdateOrder")
		  .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
		  .ProducesProblem(StatusCodes.Status400BadRequest)
		  .ProducesProblem(StatusCodes.Status404NotFound)
		  .WithSummary("Update an existsing Order")
		  .WithDescription("This endpoint allows you to update an existsing Order.");

	}
}