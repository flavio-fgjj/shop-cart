using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Entities;

public class User
{
    public int Id { get; set; }
    [MaxLength(60)]
    public string UserName { get; set; } = string.Empty;

    public Cart? Cart { get; set; } // explicit relationship (one to one)
}
