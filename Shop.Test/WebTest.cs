using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shop.Models.DTOs;
using Shop.Web.Pages.Components.Cart;
using Shop.Web.Pages.Components.Products;
using Shop.Web.Services;
using Shop.Web.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Test
{
    public class WebTest : TestContext
    {
        [Fact]
        public void RenderHyperlinks()
        {
            var cartBuyServiceMoq = new Mock<ICartBuyService>();
            var productsServiceMoq = new Mock<IProductService>();

            Services.AddSingleton<ICartBuyService>(cartBuyServiceMoq.Object);
            Services.AddSingleton<IProductService>(productsServiceMoq.Object);

            // act
            var cut = RenderComponent<ProductsCategoryNavMenu>();

            cut.Find("#menu_Beleza").Click();


            var nav = Services.GetRequiredService<NavigationManager>();

            // assert
            Assert.Equal("https://localhost:7000/ProductsByCategory/1", nav.Uri);

        }
    }
}