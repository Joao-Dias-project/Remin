using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remin.Application.Services.Contracts;
using Remin.Application.Services.Contracts.RepositoryContracts;
using Remin.Application.Services.Contracts.ServiceContracts;
using Remin.Application.Services.Services;
using Remin.Infra.Data.Repositories;

namespace Remin.Infra.Data.IoC
{
    public static class DependencyContainer
    {
        public static void AddWebApiConfigurations(this IServiceCollection services, IConfiguration config)

        {
            // Services
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IRealtyAssetService, RealtyAssetService>();

            // Repos
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IRealtyAssetRepository, RealtyAssetRepository>();
            services.AddScoped<DbContext, ApplicationDbContext>();

            // Database Config
            services.AddReminDatabase(config);
        }

        public static IServiceCollection AddReminDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = config.GetConnectionString("ReminCS");
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Remin.Services.WebApi").MigrationsHistoryTable("__EFMigrationsHistory_Data"));
            });
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return services;
        }
    }
}
