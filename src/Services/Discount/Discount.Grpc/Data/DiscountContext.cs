namespace Discount.Grpc.Data;

using Microsoft.EntityFrameworkCore;
using Entities;

public class DiscountContext(DbContextOptions<DiscountContext> options)
    : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; init; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                ProductName = "Samarkand Pilaf",
                Description = "Delicious pilaf with lamb and vegetables",
                Amount = 10
            },
            new Coupon
            {
                Id = 2,
                ProductName = "Tashkent Salad",
                Description = "Fresh salad with seasonal vegetables",
                Amount = 5
            });

    }
}