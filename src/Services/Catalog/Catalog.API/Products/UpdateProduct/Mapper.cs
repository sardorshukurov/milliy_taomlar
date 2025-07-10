namespace Catalog.API.Products.UpdateProduct;

using Endpoint;
using Handler;

public static class Mapper
{
   public static UpdateProductCommand ToCommand(this UpdateProductRequest request)
   {
      return new UpdateProductCommand(
         request.Id,
         request.Name,
         request.Categories,
         request.Description,
         request.ImageFile, 
         request.Price);
   } 
   
   public static UpdateProductResponse ToResponse(this UpdateProductResult result)
   {
      return new UpdateProductResponse(result.IsSuccess);
   }
}