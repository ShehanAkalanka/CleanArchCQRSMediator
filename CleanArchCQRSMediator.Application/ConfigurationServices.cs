using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchCQRSMediator.Application
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // Example: services.AddTransient<IMyService, MyService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}