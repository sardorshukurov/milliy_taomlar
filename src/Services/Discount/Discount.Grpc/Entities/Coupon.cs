namespace Discount.Grpc.Entities;

public class Coupon
{
    public int Id { get; init; }

    public string ProductName { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int Amount { get; set; }

    public static Coupon GetEmptyDiscount()
    {
        return new Coupon
        {
            Id = -1,
            ProductName = "No Discount",
            Amount = 0,
            Description = "No discount available for this product"
        };
    }
}