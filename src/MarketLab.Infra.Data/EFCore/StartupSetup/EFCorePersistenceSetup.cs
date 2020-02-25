using MarketLab.Domain.Core.Interfaces.Data;
using MarketLab.Infra.Data.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketLab.Infra.Data.EFCore.StartupSetup
{
    public static class EFCorePersistenceSetup
    {
        public static void AddEFCorePersistence(this IServiceCollection services, string connectionStrings, string migrationAssembly)
        {
            services.AddDbContext<MarketLabDbContext>(options => options.UseNpgsql(connectionStrings, m => m.MigrationsAssembly(migrationAssembly)));

            services.AddHealthChecks()
                .AddDbContextCheck<MarketLabDbContext>();

            services.AddScoped<IDbContext, MarketLabDbContext>();
            services.AddScoped<IMarketLabDbContext, MarketLabDbContext>();
        }
    }
}