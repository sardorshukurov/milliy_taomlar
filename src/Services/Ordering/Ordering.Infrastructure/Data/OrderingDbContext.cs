namespace Ordering.Infrastructure.Data;

using System.Reflection;
using Application.Data;

public class OrderingDbContext(DbContextOptions<OrderingDbContext> options)
    : DbContext(options), IOrderingDbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
