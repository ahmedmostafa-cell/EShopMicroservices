﻿using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        //services.AddMediatR(config =>
        //{
        //    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        //});

        return services;
    }
}
