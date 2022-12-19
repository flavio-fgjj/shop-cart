using Shop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace Shop.Web.Services;

public class ProductService : IProductService
{
    public HttpClient _httpClient;

    public ILogger<ProductService> _logger;

    public ProductService(HttpClient httpClient,
        ILogger<ProductService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductDto>> GetItems()
    {
        try
        {
            var productsDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");
            return productsDto;
        }
        catch (Exception)
        {
            _logger.LogError("Error access : api/products");
            throw;
        }
    }

    public async Task<ProductDto> GetItem(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode == HttpStatusCode.NoContent 
                    ? default(ProductDto) 
                    : await response.Content.ReadFromJsonAsync<ProductDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Error to get product by id= {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Error to get product by id={id}");
            throw;
        }
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Products/GetCategories");
            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode == System.Net.HttpStatusCode.NoContent
                    ? Enumerable.Empty<CategoryDto>()
                    : await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Error to get categories");
            throw;
        }
    }

    public async Task<IEnumerable<ProductDto>> GetItemsByCategory(int categoryId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Products/{categoryId}/GetItemsByCategory");

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode == System.Net.HttpStatusCode.NoContent
                    ? Enumerable.Empty<ProductDto>()
                    : await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Error to get itemm by category");
            throw;
        }
    }
}
