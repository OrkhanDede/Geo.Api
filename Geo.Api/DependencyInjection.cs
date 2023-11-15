using Geo.Api.DataAccess;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Geo.Api;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjections(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .ConfigureSwagger()
            .ConfigureDatabase()
            .AddMediator()
            .AddSignalR();
        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Geo.Api", Version = "v1" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("GeoDb"));

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}