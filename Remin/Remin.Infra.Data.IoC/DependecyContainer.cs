using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remin.Application.Services.Contracts;

namespace Remin.Infra.Data.IoC
{
    public static class DependencyContainer
    {
        public static void AddWebApiConfigurations(this IServiceCollection services, IConfiguration config)

        {
            // Services
            //services.AddScoped<IWorkOrderService, WorkOrderService>();
            //services.AddScoped<IMotorcycleService, MotorcycleService>();
            //services.AddScoped<IClientService, ClientService>();

            // Repos
            //services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
            //services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            //services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<DbContext, ApplicationDbContext>();

            // Database Config
            services.AddReminDatabase(config);
        }

        public static IServiceCollection AddReminDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = config.GetConnectionString("PoweredByXixoCS");
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("PoweredByXixo.Services.WebApi").MigrationsHistoryTable("__EFMigrationsHistory_Data"));
            });
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return services;
        }
    }
}
