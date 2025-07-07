namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(a => a.Quantity * a.Price);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart()
        {
            
        }
    }
}
