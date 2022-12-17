using Shop.Api.Entities;
using Shop.Models.DTOs;

namespace Shop.Api.Mappings;

public static class MappingDtos
{
    // extensions methods
    public static IEnumerable<CategoryDto> MapCategoriesToDto(
                                            this IEnumerable<Category> categories)
    {
        return (from category in categories
                select new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    IconCSS = category.IconCSS
                }).ToList();
    }

    public static IEnumerable<ProductDto> MapProductsToDto(
                                         this IEnumerable<Product> products)
    {
        return (from product in products
                select new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Total = product.Total,
                    CategoryId = product.Category.Id,
                    CategoryName = product.Category.Name
                }).ToList();
    }

    public static ProductDto MapProductToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Total = product.Total,
            CategoryId = product.Category.Id,
            CategoryName = product.Category.Name
        };
    }

    public static IEnumerable<CartItemDto> MapCartItensToDto(
        this IEnumerable<CartItem> cartItens, IEnumerable<Product> products)
    {
        return (from cartItem in cartItens
                join product in products
                on cartItem.ProductId equals product.Id
                select new CartItemDto
                {
                    Id = cartItem.Id,
                    ProductId = cartItem.ProductId,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductImageUrl = product.ImageUrl,
                    Price = product.Price,
                    CartId = cartItem.CartId,
                    Total = cartItem.Total,
                    FinalPrice = product.Price * cartItem.Total
                }).ToList();
    }

    public static CartItemDto MapCartItemToDto(this CartItem cartItem,
                                               Product product)
    {
        return new CartItemDto
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = product.Name,
            ProductDescription = product.Description,
            ProductImageUrl = product.ImageUrl,
            Price = product.Price,
            CartId = cartItem.CartId,
            Total = cartItem.Total,
            FinalPrice = product.Price * cartItem.Total
        };
    }

}
