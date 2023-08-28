using core.Interfaces;
using Infrastructure.Repository;
using Infraestructura.UnitOfWork;

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IPais, PaisRepository>();
        //servies.AddScoped<ITipoPersona, TipoPersonaRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}