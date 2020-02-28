using MarketLab.API.StartupSetup;
using MarketLab.Application.Core.Settings;
using MarketLab.Application.StartupSetup;
using MarketLab.Infra.Data.EFCore.StartupSetup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarketLab.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public AppSettings appSettings = new AppSettings();

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("AppSettings", appSettings);

            services.AddSingleton(appSettings);

            services.AddEFCorePersistence(appSettings.ConnectionStrings, appSettings.MigrationAssembly);
            services.AddInfraDataEFCore();
            services.AddMarketLabApplication();


            services.AddControllers();
            services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

            services.AddSwaggerSetup();
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwaggerSetup();

        }
    }
}