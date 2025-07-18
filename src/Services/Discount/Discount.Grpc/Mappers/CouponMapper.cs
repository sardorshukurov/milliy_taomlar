namespace Discount.Grpc.Mappers;

using Entities;

public static class CouponMapper
{
    public static CouponModel ToModel(this Coupon coupon)
    {
        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount
        };
    }
    
    public static Coupon ToEntity(this CreateDiscountRequest request)
    {
        return new Coupon
        {
            ProductName = request.ProductName,
            Description = request.Description,
            Amount = request.Amount
        };
    }
}