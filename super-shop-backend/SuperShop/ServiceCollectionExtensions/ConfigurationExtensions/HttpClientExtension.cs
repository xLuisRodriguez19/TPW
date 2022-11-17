namespace SuperShop.ServiceCollectionExtensions.ConfigurationExtensions;

public static class HttpClientExtension
{
    public static IServiceCollection ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient();
        
        return services;
    }
}