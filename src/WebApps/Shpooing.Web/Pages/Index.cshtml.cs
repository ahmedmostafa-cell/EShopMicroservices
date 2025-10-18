
namespace Shpooing.Web.Pages;

public class IndexModel (ILogger<IndexModel> logger , ICatalogService catalogService , IBasketService basketService) : PageModel
{
    public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        logger.LogInformation("index page is visited");
        var result = await catalogService.GetProducts();
        ProductList = result.Products;

        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("add to cart button clicked");
        var product = await catalogService.GetProductsById(productId);

        var basket= await basketService.LoadUserBasket();
        basket.Items.Add(new ShoppingCartItemModel
        {
            ProductId = productId,
            ProductName = product.Product.Name,
            Price = product.Product.Price,
            Quantity = 1,
            Color = "Black"
        });
       
        StoreBasketRequest request = new StoreBasketRequest(basket);
        
        var result = await basketService.StoreBasketRequest(request);

        return RedirectToPage("Cart");
    }
}
