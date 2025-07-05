
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : IQuery<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    internal class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
        : IQueryHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling DeleteProductQuery");
           
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
