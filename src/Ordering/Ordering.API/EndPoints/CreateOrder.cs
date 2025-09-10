namespace Ordering.API.EndPoints;

public record CreateOrderRequest(OrderDto orderDto);

public record CreateOrderResponse(Guid orderID);

public class CreateOrder : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/orders" , async (CreateOrderRequest request , ISender sender)=> 
		{
			var command = request.Adapt<CreateOrderCommand>();
			var result  =await sender.Send(command);
			var response = result.Adapt<CreateOrderResponse>();
			return Results.Created($"/orders/{response.orderID}", response);
		})
		 .WithName("CreateOrder")
		 .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
		 .ProducesProblem(StatusCodes.Status400BadRequest)
		 .WithSummary("Creates a new order")
		 .WithDescription("This endpoint allows you to create a new order.");
	}
}
