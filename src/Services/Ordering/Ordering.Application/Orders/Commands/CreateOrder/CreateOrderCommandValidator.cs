namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Customer ID is required");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.ShippingAddress).NotEmpty().WithMessage("Shipping address is required");
        RuleFor(c => c.BillingAddress).NotEmpty().WithMessage("Billing address is required");
        RuleFor(c => c.Payment).NotEmpty().WithMessage("Payment is required");
        RuleFor(c => c.Items).NotEmpty().WithMessage("Items are required");

        RuleFor(c => c.Items).Must(items => items.Count > 0).WithMessage("At least one item is required");
        RuleFor(c => c.Items).Must(items => items.All(item => item.Quantity > 0)).WithMessage("Quantity must be greater than 0 for each item");
        RuleFor(c => c.Items).Must(items => items.All(item => item.Price > 0)).WithMessage("Price must be greater than 0");
        RuleFor(c => c.Items).Must(items => items.All(item => item.ProductId != Guid.Empty)).WithMessage("Product ID is required for each item");
        RuleFor(c => c.Items).Must(items => items.All(item => item.OrderId != Guid.Empty)).WithMessage("Order ID is required for each item");

        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.FirstName)).WithMessage("First name is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.LastName)).WithMessage("Last name is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.Email)).WithMessage("Email is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.AddressLine)).WithMessage("Address line is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.Country)).WithMessage("Country is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.State)).WithMessage("State is required");
        RuleFor(c => c.ShippingAddress).Must(address => !string.IsNullOrWhiteSpace(address.ZipCode)).WithMessage("Zip code is required");

        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.FirstName)).WithMessage("First name is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.LastName)).WithMessage("Last name is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.Email)).WithMessage("Email is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.AddressLine)).WithMessage("Address line is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.Country)).WithMessage("Country is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.State)).WithMessage("State is required");
        RuleFor(c => c.BillingAddress).Must(address => !string.IsNullOrWhiteSpace(address.ZipCode)).WithMessage("Zip code is required");

        RuleFor(c => c.Payment).Must(payment => !string.IsNullOrWhiteSpace(payment.CardNumber)).WithMessage("Card number is required");
        RuleFor(c => c.Payment).Must(payment => !string.IsNullOrWhiteSpace(payment.CardHolderName)).WithMessage("Card holder name is required");
        RuleFor(c => c.Payment).Must(payment => !string.IsNullOrWhiteSpace(payment.CardExpiration)).WithMessage("Card expiration is required");
        RuleFor(c => c.Payment).Must(payment => !string.IsNullOrWhiteSpace(payment.CardSecurityCode)).WithMessage("Card security code is required");
    }
}
