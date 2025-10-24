namespace Shpooing.Web.Pages;

public class CheckOutModel(ILogger<CheckOutModel> logger,
IBasketService basketService) : PageModel
{
    [BindProperty]
    public BasketCheckoutModel Order { get; set; } = default!;
    public ShoppingCartModel Cart { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();

        return Page();
    }

    public async Task<IActionResult> OnPostCheckoutAsync()
    {
        logger.LogInformation("Checkout button clicked");
        Cart = await basketService.LoadUserBasket();
        if(!ModelState.IsValid)
        {
            return Page();
        }
        Order.TotalPrice = Cart.TotalPrice;
        Order.UserName = Cart.UserName;
        Order.CustomerId = new Guid("b4c23a11-0a02-4761-9cd4-7d7a37b1091f");
        var response = await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));
        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}
