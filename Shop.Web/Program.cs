using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shop.Web;
using Shop.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



var baseUrl = "https://localhost:7264";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartBuyService, CartBuyService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IManagerProductsLocalStorageService, ManagerProductsLocalStorageService>();
builder.Services.AddScoped<IManagerCartItemsLocalStorageService, ManagerCartItemsLocalStorageService>();

builder.Services.AddLocalization();

await builder.Build().RunAsync();
