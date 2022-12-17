using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DTOs;

public class CartItemAddNewItemDto
{
    // data anotations to validate
    [Required]
    public int CartId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Total { get; set; }
}
