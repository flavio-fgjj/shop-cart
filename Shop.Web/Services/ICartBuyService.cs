using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface ICartBuyService
{
    Task<List<CartItemDto>> GetItems(string userId);
    Task<CartItemDto> AddItem(CartItemAddNewItemDto cartItemAddNewItemDto);
    Task<CartItemDto> RemoveItem(int id);
}
