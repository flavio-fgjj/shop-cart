
using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface IManagerProductsLocalStorageService
{
    Task<IEnumerable<ProductDto>> GetCollection();
    Task RemoveCollection();
}
