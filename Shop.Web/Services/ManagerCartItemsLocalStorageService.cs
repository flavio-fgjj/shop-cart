using Blazored.LocalStorage;
using Shop.Models.DTOs;

namespace Shop.Web.Services;

public class ManagerCartItemsLocalStorageService : IManagerCartItemsLocalStorageService
{
    private const string key = "CartItemCollection";

    private readonly ILocalStorageService localStorageService;
    private readonly ICartBuyService cartBuyService;

    public ManagerCartItemsLocalStorageService(ILocalStorageService localStorageService, ICartBuyService cartBuyService)
    {
        this.localStorageService = localStorageService;
        this.cartBuyService = cartBuyService;
    }

    public async Task<List<CartItemDto>> GetCollection()
    {
        return await this.localStorageService.GetItemAsync<List<CartItemDto>>(key) ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this.localStorageService.RemoveItemAsync(key);
    }

    public async Task SaveCollection(List<CartItemDto> cartItemsDto)
    {
        await this.localStorageService.SetItemAsync(key, cartItemsDto);
    }

    //getting data from server and store at localStorage
    private async Task<List<CartItemDto>> AddCollection()
    {
        var cartBuyCollection = await this.cartBuyService.GetItems(LoggedUser.UserId);

        if (cartBuyCollection != null)
            await this.localStorageService.SetItemAsync(key, cartBuyCollection);

        return cartBuyCollection;
    }
}
