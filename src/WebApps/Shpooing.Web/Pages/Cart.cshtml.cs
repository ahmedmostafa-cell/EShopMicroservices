namespace Shpooing.Web.Pages;

public class CartModel(IBasketService basketService , ILogger<CartModel> logger) : PageModel
{
    public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();
    public async Task<IActionResult>  OnGetAsync()
    {
        logger.LogInformation("cart page is visited");
        Cart = await basketService.LoadUserBasket();

        return Page();
    }

    public async Task<IActionResult> OnPostRemovetocartAsync(Guid productId)
    {
        logger.LogInformation("remove from cart button clicked");
        var basket = await basketService.LoadUserBasket();
        var itemToRemove = basket.Items.FirstOrDefault(x => x.ProductId == productId);
        if (itemToRemove != null)
        {
            basket.Items.RemoveAll(a=> a.ProductId == itemToRemove.ProductId);
        }
        StoreBasketRequest request = new StoreBasketRequest(basket);
        var result = await basketService.StoreBasketRequest(request);

        return RedirectToPage();
    }
}
