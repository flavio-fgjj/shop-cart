using Shop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace Shop.Web.Services;

public class CartBuyService : ICartBuyService
{
    private readonly HttpClient _httpClient;

    public CartBuyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public event Action<int> OnCartBuyChanged;

    public async Task<CartItemDto> AddItem(CartItemAddNewItemDto cartItemAddNewItemDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<CartItemAddNewItemDto>("api/CartBuy", cartItemAddNewItemDto);

            if (response.IsSuccessStatusCode)// status code between 200 a 299
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    // return empty or default value
                    return default(CartItemDto);
                }
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode} Message -{message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<CartItemDto>> GetItems(string userId)
    {
        try
        {
            //envia um request GET para a uri da API CarrinhoCompra
            var response = await _httpClient.GetAsync($"api/CartBuy/{userId}/GetItens");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartItemDto>().ToList();
                }
                return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code: {response.StatusCode} Message: {message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemDto> RemoveItem(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/CartBuy/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            return default(CartItemDto);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
