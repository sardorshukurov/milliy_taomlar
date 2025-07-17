namespace Basket.API.Entities;

public class ShoppingCartItem
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public float Size
    {
        get => _size;
        set => _size = Math.Max(1, value);
    }

    public decimal Price { get; set; }

    private float _size = 1;
}
