using System.Reflection;
using AutoMapper;
using MarketLab.Application.Core.AutoMapper;
using MarketLab.Application.Products.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.Application.StartupSetup
{
    public static class ApplicationSetup
    {
        public static void AddMarketLabApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(ProductAutomapperProfile));
            services.AddScoped<IProductService, ProductService>();
        }
    }
}