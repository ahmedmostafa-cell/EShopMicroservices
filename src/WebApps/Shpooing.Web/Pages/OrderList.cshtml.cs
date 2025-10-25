namespace Shpooing.Web.Pages;

    public class OrderListModel(ILogger<OrderListModel> logger,
        IOrderingService orderingService) : PageModel
    {
	public IEnumerable<OrderModel> Orders { get; set; } = default!;

	public async Task<IActionResult> OnGetAsync()
	{
		var getOrderResponse = await orderingService.GetOrderByCustomer(Guid.Parse("b4c23a11-0a02-4761-9cd4-7d7a37b1091f"));
		Orders = getOrderResponse.Orders;

		return Page();
	}
}
