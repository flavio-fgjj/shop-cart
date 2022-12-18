using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItems();
    Task<ProductDto> GetItem(int id);
}