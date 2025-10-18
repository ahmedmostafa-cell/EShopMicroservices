using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shpooing.Web.Pages
{

    public class ProductDetailModel(ILogger<ProductDetailModel> logger,
    ICatalogService catalogService, IBasketService basketService) : PageModel
    {
        public IEnumerable<string> CategoryList { get; set; } = [];
        public ProductModel Product { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var result = await catalogService.GetProducts();
            CategoryList = result.Products
                .SelectMany(p => p.Category)
                .Distinct()
                .OrderBy(c => c);
            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    ProductList = ProductList
            //        .Where(p => p.Category.Contains(categoryName, StringComparer.OrdinalIgnoreCase));
            //}
            //else
            //{
            //    ProductList = result.Products;

            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("add to cart button clicked");
            var product = await catalogService.GetProductsById(productId);

            var basket = await basketService.LoadUserBasket();
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
}
