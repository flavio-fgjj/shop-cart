using Shop.Models.DTOs;
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
}
