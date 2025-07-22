namespace Ordering.Domain.Entities;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public static Customer Create(string name, string email)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(email);

        var customerId = CustomerId.New();
        var customer = new Customer
        {
            Id = customerId,
            Name = name,
            Email = email
        };

        return customer;
    }
}
