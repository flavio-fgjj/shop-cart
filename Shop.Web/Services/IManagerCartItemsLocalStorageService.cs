using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface IManagerCartItemsLocalStorageService
{
    Task<List<CartItemDto>> GetCollection();
    Task SaveCollection(List<CartItemDto> cartItemsDto);
    Task RemoveCollection();
}
