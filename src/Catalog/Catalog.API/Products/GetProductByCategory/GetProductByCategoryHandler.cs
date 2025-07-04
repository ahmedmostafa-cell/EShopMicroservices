namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string categoryName)
        : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryHandler(IDocumentSession session, 
        ILogger<GetProductByCategoryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductByCategoryQuery");
            var products = await session.Query<Product>()
             .Where(p => p.Category.Contains(query.categoryName))
             .ToListAsync(cancellationToken);
           
            return new GetProductByCategoryResult(products);
        }
    }
}
