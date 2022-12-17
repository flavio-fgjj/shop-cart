using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Entities;

public class Category
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string IconCSS { get; set; } = string.Empty;

    public Collection<Product> Products { get; set; } = new Collection<Product>(); // explicit relationship (one to many)

}
