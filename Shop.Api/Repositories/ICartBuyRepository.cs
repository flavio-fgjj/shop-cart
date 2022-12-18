using Shop.Api.Entities;
using Shop.Models.DTOs;

namespace Shop.Api.Repositories;

public interface ICartBuyRepository
{
    Task<CartItem> AddItem(CartItemAddNewItemDto cartItemAddNewItemDto);

    Task<CartItem> UpdateTotal(int id, CartItemUpdateTotalDto cartItemUpdateTotalDto);

    Task<CartItem> RemoveItem(int id);

    Task<CartItem> GetItem(int id);

    Task<IEnumerable<CartItem>> GetItems(string usuarioId);
}
