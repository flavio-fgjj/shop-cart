namespace Shop.Api.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Cart? Cart { get; set; } // explicit relationship (one to one)
}
