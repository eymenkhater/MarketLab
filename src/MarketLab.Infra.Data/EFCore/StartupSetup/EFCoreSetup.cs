using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Domain.Core.Interfaces.Data.BulkRepositories;
using MarketLab.Domain.Core.Interfaces.Data.Repositories;
using MarketLab.Infra.Data.EFCore.BulkRepositories;
using MarketLab.Infra.Data.EFCore.Repositories;
using MarketLab.Infra.Data.EFCore.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.Infra.Data.EFCore.StartupSetup
{
    public static class EFCoreSetup
    {
        public static void AddInfraDataEFCore(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IUnitOfWorkRepository<>), typeof(EFUnitOfWorkRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();

            services.AddScoped<IBulkProductRepository, BulkProductRepository>();
        }
    }
}