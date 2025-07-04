namespace Catalog.API.Exception
{
    public class ProductNotFoundException : IOException
    {
        public ProductNotFoundException() : base("Product not found.")
        {
        }
        
    }
}
