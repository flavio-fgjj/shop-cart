using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shop.Web.Pages;
using Shop.Web.Services;
using Shop.Web.Shared;
using System;
using Xunit;

namespace Shop.Test
{
    public class WebTest : TestContext
    {
        //[Fact]
        //public void RenderHyperlinks()
        //{
        //    var cartBuyServiceMoq = new Mock<ICartBuyService>();
        //    var productsServiceMoq = new Mock<IProductService>();

        //    Services.AddSingleton<ICartBuyService>(cartBuyServiceMoq.Object);
        //    Services.AddSingleton<IProductService>(productsServiceMoq.Object);

        //    // act
        //    var cut = RenderComponent<ProductsCategoryNavMenu>();

        //    cut.Find("#menu_Beleza").Click();


        //    var nav = Services.GetRequiredService<NavigationManager>();

        //    // assert
        //    Assert.Equal("https://localhost:7000/ProductsByCategory/1", nav.Uri);

        //}

        [Fact]
        public void RenderimageLogo()
        {
            // act
            var cut = RenderComponent<Web.Pages.Index>();
            //cut.Find("#image-logo");

            // assert
            var expectedMarkup = @"<div class=""text-center"" ><img id=""image-logo"" src=""/shopping-cart2.jpg"" class=""rounded"" asp-append-version=""true"" alt=""Shopping Cart"" ></div>";

            cut.MarkupMatches(expectedMarkup);

        }
    }
}