namespace Shpooing.Web.Models.Basket
{
	public class ShoppingCartModel
	{
		public string UserName { get; set; } = default!;
		public List<ShoppingCartItemModel> Items { get; set; } = new();
		public decimal TotalPrice => Items.Sum(a => a.Quantity * a.Price);
	}

	public record StoreBasketRequest(ShoppingCartModel Cart);
	public record StoreBasketResponse(string UserName);

	public record GetBasketResponse(ShoppingCartModel Cart);
	public record DeleteBasketResponse(bool IsSuccess);

}
