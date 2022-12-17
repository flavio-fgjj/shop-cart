namespace Shop.Models.DTOs;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Total { get; set; }


    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductImageUrl { get; set; }
    public decimal Price { get; set; }
    public decimal FinalPrice { get; set; }
}
