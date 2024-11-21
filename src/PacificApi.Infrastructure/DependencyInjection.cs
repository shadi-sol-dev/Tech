using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PacificApi.Application.Interfaces;
using PacificApi.Infrastructure.DbContext;

namespace PacificApi.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string?  connectionString)
    {
        services.AddDbContext<ImageDbContext>(options =>
            options.UseSqlite(connectionString));
        services.AddScoped<IImageRepository, ImageRepository>();

        return services;
    }

}