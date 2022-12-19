using Shop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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
                return response.StatusCode == HttpStatusCode.NoContent 
                    ? default(CartItemDto) // return empty or default value
                    : await response.Content.ReadFromJsonAsync<CartItemDto>();
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
            var response = await _httpClient.GetAsync($"api/CartBuy/{userId}/GetItems");

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode == System.Net.HttpStatusCode.NoContent
                    ? Enumerable.Empty<CartItemDto>().ToList()
                    : await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
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

    public void RaiseEventOnCartBuyChanged(int total)
    {
        if (OnCartBuyChanged != null)
            OnCartBuyChanged.Invoke(total);
    }

    public async Task<CartItemDto> RemoveItem(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/CartBuy/{id}");

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<CartItemDto>()
                : default(CartItemDto);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemDto> UpdateItem(CartItemUpdateTotalDto cartItemUpdateTotalDto)
    {
        try
        {
            var jsonRequest = JsonSerializer.Serialize(cartItemUpdateTotalDto);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

            var response = await _httpClient.PatchAsync($"api/CartBuy/{cartItemUpdateTotalDto.CartItemid}", content);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<CartItemDto>()
                : new CartItemDto();

        }
        catch (Exception)
        {
            throw;
        }

    }
}
