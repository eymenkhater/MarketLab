using AutoMapper;
using MarketLab.Application.Core.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.Application.StartupSetup
{
    public static class ApplicationSetup
    {
        public static void MarketLabApplicationSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductAutomapperProfile));
        }
    }
}