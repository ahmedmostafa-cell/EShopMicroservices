namespace Shpooing.Web.Services;

public interface ICatalogService
{
	[Get("/catalog-service/products?PageNumber={PageNumber}&PageSize={PageSize}")]
    Task<GetProductsResponse> GetProducts(int? PageNumber = 1, int? PageSize = 10);

    [Get("/catalog-service/products/{id}")]
    Task<GetProductByIdResponse> GetProductsById(Guid id);

    [Get("/catalog-service/products/category/{categoryName}")]
    Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName);

}
