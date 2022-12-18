using Shop.Models.DTOs;

namespace Shop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetItems();
}