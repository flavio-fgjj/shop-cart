using Microsoft.EntityFrameworkCore;
using Shop.Api.Context;
using Shop.Api.Entities;
using Shop.Models.DTOs;

namespace Shop.Api.Repositories
{
    public class CartBuyRepository : ICartBuyRepository
    {
        private readonly AppDbContext _context;

        public CartBuyRepository(AppDbContext context)
        {
            _context = context;
        }

        private async Task<bool> ItemCartExists(int cartId, int productId)
        {
            return await _context.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                              c.ProductId == productId);
        }

        public async Task<CartItem> AddItem(CartItemAddNewItemDto cartItemAddNewItemDto)
        {
            if (await ItemCartExists(cartItemAddNewItemDto.CartId,
            cartItemAddNewItemDto.ProductId) == false)
            {
                //check if the products exists
                //add new item to cart
                var item = await(from product in _context.Products
                                 where product.Id == cartItemAddNewItemDto.ProductId
                                 select new CartItem
                                 {
                                     CartId = cartItemAddNewItemDto.CartId,
                                     ProductId = product.Id,
                                     Total = cartItemAddNewItemDto.Total
                                 }).SingleOrDefaultAsync();

                //include if exists
                if (item is not null)
                {
                    var resultado = await _context.CartItems.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return new CartItem();
        }

        public async Task<CartItem> GetItem(int id)
        {
            var ret = await (from cart in _context.Carts
                             join cartItem in _context.CartItems
                             on cart.Id equals cartItem.CartId
                             where cartItem.Id == id
                             select new CartItem
                             {
                                 Id = cartItem.Id,
                                 ProductId = cartItem.ProductId,
                                 Total = cartItem.Total,
                                 CartId = cartItem.CartId
                             }).SingleOrDefaultAsync();
            return ret ?? new CartItem();
        }

        public async Task<IEnumerable<CartItem>> GetItems(string userId)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Total = cartItem.Total,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public Task<CartItem> RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> UpdateTotal(int id, CartItemUpdateTotalDto cartItemUpdateTotalDto)
        {
            throw new NotImplementedException();
        }
    }
}
