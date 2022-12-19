using Shop.Api.Entities;

namespace Shop.Api.Repositories;

public interface IProductRepository
{
    // defining contracts for Product and these contracts should be implemented by who will use
    Task<IEnumerable<Product>> GetItems();
    Task<Product> GetItem(int id);
    Task<IEnumerable<Product>> GetItemsByCategory(int id);
    Task<IEnumerable<Category>> GetCategories();

}
