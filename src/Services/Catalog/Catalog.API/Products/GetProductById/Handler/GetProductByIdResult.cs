using Catalog.API.Products.Dtos;

namespace Catalog.API.Products.GetProductById.Handler;

public record GetProductByIdResult(ProductDto? Product);
