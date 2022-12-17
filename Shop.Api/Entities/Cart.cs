using System.Collections.ObjectModel;

namespace Shop.Api.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public Collection<CartItem> Items { get; set; } = new Collection<CartItem>(); // explicit relationship (one to many)
}
