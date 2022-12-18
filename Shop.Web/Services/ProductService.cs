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
}
