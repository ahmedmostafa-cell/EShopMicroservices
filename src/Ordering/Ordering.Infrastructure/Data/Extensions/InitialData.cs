using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
       Customer.Create(CustomerId.Of(new Guid("b4c23a11-0a02-4761-9cd4-7d7a37b1091f")) ,
           "mehmet" , "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("f0c4e73f-d845-4f56-9f8d-80124f91f3a2")) ,
           "john" , "john@gmail.com")

    };

    public static IEnumerable<Product> Products => new List<Product>
    {
       Product.Create(ProductID.Of(new Guid("b4c23a11-0a02-4761-9cd4-7d7a37b1091f")) ,
           "I Phone X" , 500),
        Product.Create(ProductID.Of(new Guid("f0c4e73f-d845-4f56-9f8d-80124f91f3a2")) ,
           "Samsung 10" , 400),
         Product.Create(ProductID.Of(new Guid("3c4a76aa-5f3f-4e0f-9b7d-6e8c17d5c39e")) ,
           "Huwaei Plus" , 650),
         Product.Create(ProductID.Of(new Guid("91de0cf6-6d62-4c70-87f2-760a268d3571")) ,
           "Xiaomi Mi" , 450)

    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4"
                , "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1",
                "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("b4c23a11-0a02-4761-9cd4-7d7a37b1091f")),
            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductID.Of(new Guid("b4c23a11-0a02-4761-9cd4-7d7a37b1091f")), 2, 500);
            order1.Add(ProductID.Of(new Guid("f0c4e73f-d845-4f56-9f8d-80124f91f3a2")), 1, 400);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("f0c4e73f-d845-4f56-9f8d-80124f91f3a2")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductID.Of(new Guid("3c4a76aa-5f3f-4e0f-9b7d-6e8c17d5c39e")), 1, 650);
            order2.Add(ProductID.Of(new Guid("91de0cf6-6d62-4c70-87f2-760a268d3571")), 2, 450);

            return new List<Order> { order1, order2 };
        }

    }
}
