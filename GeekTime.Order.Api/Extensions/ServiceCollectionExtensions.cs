using GeekTime.OrderService.Domain.OrderAggregate;
using GeekTime.OrderService.Infrastructure;
using GeekTime.OrderService.Infrastructure.Repositoties;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeekTime.OrderService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(OrderContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Order).Assembly, typeof(Program).Assembly);
        }

        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<OrderContext>(optionsAction);
        }

        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }

    }
}
