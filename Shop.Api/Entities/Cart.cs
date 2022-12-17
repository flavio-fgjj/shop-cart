using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Entities;

public class Cart
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string? UserId { get; set; }

    public Collection<CartItem> Items { get; set; } = new Collection<CartItem>(); // explicit relationship (one to many)
}
