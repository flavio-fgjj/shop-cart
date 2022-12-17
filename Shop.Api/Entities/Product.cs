using System.Collections.ObjectModel;

namespace Shop.Api.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; } = string.Empty;

    public int? Total { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Collection<CartItem> Items { get; set; } = new Collection<CartItem>(); // explicit relationship (one to many)
}
