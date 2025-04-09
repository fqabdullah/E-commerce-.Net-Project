using BlazorBay.Models;

namespace BlazorBay.Services;

public class CartService
{
    public event Action? OnChange;
    private List<Product> items = new();

    public IReadOnlyList<Product> Items => items;

    public void AddToCart(Product product)
    {
        items.Add(product);
        OnChange?.Invoke();
    }

    public void RemoveFromCart(Product product)
    {
        items.Remove(product);
        OnChange?.Invoke();
    }

    public void Clear()
    {
        items.Clear();
        OnChange?.Invoke();
    }

    public decimal GetTotal() => items.Sum(p => p.Price);
}