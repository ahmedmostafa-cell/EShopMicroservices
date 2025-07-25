﻿namespace Basket.API.Basket.DeleteBasket
{
    //public record DeleteBasketRequest(Guid Id);  
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/baskets/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(UserName));
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            })
           .WithName("DeleteBasket")
           .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Delete Basket")
           .WithDescription("Delete Basket");
        }
    }
}
