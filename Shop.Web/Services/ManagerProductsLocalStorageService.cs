using Blazored.LocalStorage;
using Shop.Models.DTOs;

namespace Shop.Web.Services;

public class ManagerProductsLocalStorageService : IManagerProductsLocalStorageService
{
    private const string key = "ProductCollection";

    private readonly ILocalStorageService localStorageService;
    private readonly IProductService productService;

    public ManagerProductsLocalStorageService(ILocalStorageService localStorageService, IProductService productService)
    {
        this.localStorageService = localStorageService;
        this.productService = productService;
    }

    public async Task<IEnumerable<ProductDto>> GetCollection()
    {
        return await this.localStorageService.GetItemAsync<IEnumerable<ProductDto>>(key) ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this.localStorageService.RemoveItemAsync(key);
    }

    private async Task<IEnumerable<ProductDto>> AddCollection()
    {
        var productCollection = await this.productService.GetItems();
        if (productCollection != null)
            await this.localStorageService.SetItemAsync(key, productCollection);

        return productCollection;
    }
}
