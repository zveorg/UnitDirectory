using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitDirectory.Core.Interfaces.Repositories;
using UnitDirectory.Infrastructure.EntityFramework;
using UnitDirectory.Infrastructure.Repositories;

namespace UnitDirectory.Infrastructure.Extensions
{
    public static class InitializationExtensions
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFramework(configuration);

            services.AddScoped<IUnitRepository, UnitRepository>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseEntityFramework();

            return app;
        }

        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IUnitRepository, UnitRepository>();

            return services;
        }

        public static IApplicationBuilder UseEntityFramework(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
            }

            return app;
        }
    }
}
