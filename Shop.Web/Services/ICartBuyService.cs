using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface ICartBuyService
{
    Task<List<CartItemDto>> GetItens(string userId);
    Task<CartItemDto> AddItem(CartItemAddNewItemDto cartItemAddNewItemDto);
}
