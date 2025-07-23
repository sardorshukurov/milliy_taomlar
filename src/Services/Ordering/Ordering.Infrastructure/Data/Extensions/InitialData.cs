namespace Ordering.Infrastructure.Data.Extensions;

using Domain.ValueObjects;

internal class InitialData
{
    internal static IEnumerable<Customer> Customers => [];

    internal static IEnumerable<Product> Products =>
        [
            Product.Create(ProductId.New(), "Samsa", 15000),
            Product.Create(ProductId.New(), "Pilaf", 20000),
        ];
    
    internal static IEnumerable<Order> Orders => [];
}
