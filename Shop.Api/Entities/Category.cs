using System.Collections.ObjectModel;

namespace Shop.Api.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string IconCSS { get; set; } = string.Empty;

    public Collection<Product> Products { get; set; } = new Collection<Product>(); // explicit relationship (one to many)

}
