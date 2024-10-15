using Business.JWT;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockify.Infrastructure.JWT;

namespace Business.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration config)
    {
        JWTAuthenticationScheme.AddJWTAuthenticationScheme(services, config);

        services.AddScoped<IJwtGenerator, JwtTokenGenerator>();
        services.AddScoped<IJwtValidator, JwtValidator>();
        
        return services;
    }
}