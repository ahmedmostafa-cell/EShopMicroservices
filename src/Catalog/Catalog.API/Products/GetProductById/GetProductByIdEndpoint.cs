﻿namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product Product);

    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/getProductById/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
       .WithName("GetProductByID")
       .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Get Product By Id")
       .WithDescription("Get Product By Id");
        }
    }
}
