namespace Catalog.API.Products.UpdateProduct.Handler;

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
                StatusCodes.Status404NotFound,
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
            true, StatusCodes.Status200OK, new Unit());
    }
}