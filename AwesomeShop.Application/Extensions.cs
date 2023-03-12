using AwesomeShop.Application.Command.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddOrderHandler));

            return services;
        }
    }
}
