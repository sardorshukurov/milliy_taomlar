namespace Basket.API.Entities;

public class ShoppingCart
{
    public ShoppingCart() { }

    public ShoppingCart(string username) => Username = username;

    public string Username { get; set; } = string.Empty;

    public List<ShoppingCartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
}
