using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SuperShop.Authentication.Jwt;

namespace SuperShop.ServiceCollectionExtensions.ConfigurationExtensions;

public static class JwtConfigurationExtension
{
    public static IServiceCollection AddJwtBearerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtConfig>(options =>
        {
            options.JwtKey = configuration.GetValue<string>("JwtKey");
        });
            
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtKey")))
            };
        });
            
        return services;
    }
}