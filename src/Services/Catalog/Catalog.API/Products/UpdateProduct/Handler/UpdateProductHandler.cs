namespace Catalog.API.Products.UpdateProduct.Handler;

using System.Net;
using Entities;

public class UpdateProductHandler(IDocumentSession session)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task<Response<Unit>> Handle(
        UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            return new Response<Unit>(
                false,
                (int)HttpStatusCode.NotFound,
                new Unit(),
                "Product not found");
        }

        product.Name = command.Name;
        product.Categories = command.Categories;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Response<Unit>(
            true, (int)HttpStatusCode.OK, new Unit());
    }
}