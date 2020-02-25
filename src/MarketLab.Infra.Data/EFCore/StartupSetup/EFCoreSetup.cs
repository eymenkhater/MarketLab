using MarketLab.Domain.Core.Interfaces.Data;
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
        }
    }
}