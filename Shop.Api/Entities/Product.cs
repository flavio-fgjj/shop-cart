using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Api.Entities;

public class Product
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; } = string.Empty;
    [MaxLength(200)]
    public string? Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }
    [MaxLength(250)]
    public string? ImageUrl { get; set; } = string.Empty;

    public int? Total { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Collection<CartItem> Items { get; set; } = new Collection<CartItem>(); // explicit relationship (one to many)
}
