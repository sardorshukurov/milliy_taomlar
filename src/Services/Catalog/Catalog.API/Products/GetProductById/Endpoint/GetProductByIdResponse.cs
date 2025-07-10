using Catalog.API.Products.Dtos;

namespace Catalog.API.Products.GetProductById.Endpoint;

public record GetProductByIdResponse(ProductDto? Product);
