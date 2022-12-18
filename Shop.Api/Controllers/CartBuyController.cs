using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Mappings;
using Shop.Api.Repositories;
using Shop.Models.DTOs;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartBuyController : ControllerBase
{
    private readonly ICartBuyRepository cartBuyRepository;
    private readonly IProductRepository productRepository;

    private ILogger<CartBuyController> logger;

    public CartBuyController(
        ICartBuyRepository iCartBuyRepository,
        IProductRepository iProductRepository,
        ILogger<CartBuyController> logger)
    {
        cartBuyRepository = iCartBuyRepository;
        productRepository = iProductRepository;
        this.logger = logger;
    }

    [HttpGet]
    [Route("{userId}/GetItens")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItens(string userId)
    {
        try
        {
            var cartItems = await cartBuyRepository.GetItems(userId);
            if (cartItems == null)
                return NoContent(); // 204 Status Code

            var products = await this.productRepository.GetItems();
            if (products == null)
                throw new Exception("Products not found");

            var cartItemsDto = cartItems.MapCartItensToDto(products);
            return Ok(cartItemsDto);
        }
        catch (Exception ex)
        {
            logger.LogError("## Error to get cart items");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartItemDto>> GetItem(int id)
    {
        try
        {
            var cartItem = await cartBuyRepository.GetItem(id);
            if (cartItem == null)
                return NotFound($"Item not found"); //404 status code

            var product = await productRepository.GetItem(cartItem.ProductId);

            if (product == null)
                return NotFound($"Item don't exists");

            var cartItemDto = cartItem.MapCartItemToDto(product);

            return Ok(cartItemDto);
        }
        catch (Exception ex)
        {
            logger.LogError($"## Error to get cart item");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemAddNewItemDto cartItemAddDto)
    {
        try
        {
            var newCartItem = await cartBuyRepository.AddItem(cartItemAddDto);

            if (newCartItem == null)
                return NoContent(); //Status 204

            var product = await productRepository.GetItem(newCartItem.ProductId);

            if (product == null)
                throw new Exception($"Product not found (Id:({cartItemAddDto.ProductId})");

            var newCartItemmDto = newCartItem.MapCartItemToDto(product);

            return CreatedAtAction(nameof(GetItem), new { id = newCartItemmDto.Id },
                newCartItemmDto);

        }
        catch (Exception ex)
        {
            logger.LogError("## Error to Add Item in the Cart");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CartItemDto>> RemoveItem(int id)
    {
        try
        {
            var cartItem = await cartBuyRepository.RemoveItem(id);

            if (cartItem == null)
                return NotFound();

            var product = await productRepository.GetItem(cartItem.ProductId);

            if (product is null)
                return NotFound();

            var cartItemDto = cartItem.MapCartItemToDto(product);
            return Ok(cartItemDto);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch("{id:int}")] // partial update
    public async Task<ActionResult<CartItemDto>> UpdateTotal(int id, CartItemUpdateTotalDto cartItemUpdateTotalDto)
    {
        try
        {

            var cartItem = await cartBuyRepository.UpdateTotal(id, cartItemUpdateTotalDto);

            if (cartItem == null)
                return NotFound();

            var product = await productRepository.GetItem(cartItem.ProductId);
            var cartItemDto = cartItem.MapCartItemToDto(product);
            return Ok(cartItemDto);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
