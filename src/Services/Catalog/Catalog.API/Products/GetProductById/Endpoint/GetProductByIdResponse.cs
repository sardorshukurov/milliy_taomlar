namespace Catalog.API.Products.GetProductById.Endpoint;

using Catalog.API.Products.GetProducts.Dtos;

public record GetProductByIdResponse(ProductDto? Product);
