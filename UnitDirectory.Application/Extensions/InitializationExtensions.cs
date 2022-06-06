using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UnitDirectory.Application.Extensions
{
    public static class InitializationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddAutoMapper()
                .AddMediatR(typeof(InitializationExtensions).GetTypeInfo().Assembly);

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InitializationExtensions).GetTypeInfo().Assembly);

            return services;
        }
    }
}
