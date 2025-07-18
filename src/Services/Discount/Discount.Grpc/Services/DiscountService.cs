using Grpc.Core;

namespace Discount.Grpc.Services;

using Data;
using Entities;
using Mappers;
using Microsoft.EntityFrameworkCore;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(
        GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons
            .FirstOrDefaultAsync(c => c.ProductName == request.ProductName)
                     ?? Coupon.GetEmptyDiscount();

        logger.LogInformation("Discount is retrieved for product: {ProductName}, Amount: {Amount}",
            coupon.ProductName, coupon.Amount);
        
        return coupon.ToModel();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.ToEntity();

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully created for product: {ProductName}, Amount: {Amount}",
            coupon.ProductName, coupon.Amount);

        return coupon.ToModel();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons
            .FirstOrDefaultAsync(c => c.Id == request.Coupon.Id);

        if (coupon is null)
        {
            return Coupon.GetEmptyDiscount().ToModel();
        }
        
        coupon.ProductName = request.Coupon.ProductName;
        coupon.Description = request.Coupon.Description;
        coupon.Amount = request.Coupon.Amount;

        await dbContext.SaveChangesAsync();
        
        logger.LogInformation("Discount is successfully updated for product: {ProductName}, Amount: {Amount}",
            coupon.ProductName, coupon.Amount);
        
        return coupon.ToModel();
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons
            .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
        
        if (coupon is null)
        {
            return new DeleteDiscountResponse { Success = false };
        }
        
        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully deleted for product: {ProductName}", request.ProductName);

        return new DeleteDiscountResponse { Success = true };
    }
}