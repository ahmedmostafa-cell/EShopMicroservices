namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    internal class GetBasketHandler(IDocumentSession session)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            // ToDO Apply Repository pattern here
            var cart = await session.LoadAsync<ShoppingCart>(query.UserName, cancellationToken);
            if (cart is null)
            {
                throw new BasketNotFoundException(query.UserName);
            }

            //return new GetBasketResult(cart);
            return new GetBasketResult(new ShoppingCart("ahmed"));

        }
    }
}
