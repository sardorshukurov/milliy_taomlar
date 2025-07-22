namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string AdressLine { get; } = string.Empty;
    public string Country { get; } = string.Empty;
    public string State { get; } = string.Empty;
    public string ZipCode { get; } = string.Empty;

    protected Address() { }
    private Address(
        string firstName,
        string lastName,
        string email,
        string adressLine,
        string country,
        string state,
        string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AdressLine = adressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(
        string firstName,
        string lastName,
        string email,
        string adressLine,
        string country,
        string state,
        string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(adressLine);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(zipCode);

        return new Address(
            firstName,
            lastName,
            email,
            adressLine,
            country,
            state,
            zipCode
        );
    }
}
