namespace Catalog.API.Products.GetProductById.Handler;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
