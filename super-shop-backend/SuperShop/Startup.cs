using SuperShop.Authentication.Jwt;
using SuperShop.Business.Orders.AddOrder;
using SuperShop.Business.Login.Services;
using SuperShop.Business.Shipping.Services;
using SuperShop.ServiceCollectionExtensions.ConfigurationExtensions;
using SuperShop.Business.Tracking.Services;
using SuperShop.Business.Suggestions.Services;

namespace SuperShop;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddJwtBearerConfiguration(Configuration)
            .AddDatabase(Configuration)
            .AddSwagger(Configuration);


        services
            .AddMvc()
            .AddNewtonsoftJson();

        services.AddTransient<JwtGeneration>();

        services.AddTransient<UserService>();
        services.AddTransient<ShippingService>();
        services.AddTransient<TrackingService>();
        services.AddTransient<SuggestionsService>();
        services.AddTransient<EmailService>();
        services.AddTransient<AddOrderService>();
        
        services.AddHttpContextManager();
        services.AddLogging(builder => builder.AddConsole());
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env
    )
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoices API"); });

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}