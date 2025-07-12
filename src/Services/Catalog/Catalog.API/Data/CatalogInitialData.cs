namespace Catalog.API.Data;

using Marten.Schema;
using Entities;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
        {
            return;
        }

        session.Store(GetBaseProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetBaseProducts() =>
    [
        new ()
        {
            Id = Guid.NewGuid(),
            Name = "Wedding Pilaf",
            Categories = ["Rice", "Carrot", "Meat"],
            Description = "Traditional Uzbek dish made with rice, carrots, and meat.",
            ImageFile = "",
            Price = 38000m
        },
        new ()
        {
            Id = Guid.NewGuid(),
            Name = "Samarkand Pilaf",
            Categories = ["Rice", "Carrot", "Meat"],
            Description = "Traditional Uzbek dish made with rice, carrots, and meat.",
            ImageFile = "",
            Price = 36000m
        },
        new ()
        {
            Id = Guid.NewGuid(),
            Name = "Samosa with potato",
            Categories = ["Potato", "Onions"],
            Description = "Traditional Uzbek pastry filled with potato and onions.",
            ImageFile = "",
            Price = 5000m
        },
        new ()
        {
            Id = Guid.NewGuid(),
            Name = "Samosa with meat",
            Categories = ["Meat", "Onions"],
            Description = "Traditional Uzbek pastry filled with meat and onions.",
            ImageFile = "",
            Price = 10000m
        },
    ];
}