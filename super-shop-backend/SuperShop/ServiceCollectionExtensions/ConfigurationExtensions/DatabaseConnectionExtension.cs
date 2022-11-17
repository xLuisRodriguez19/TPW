using Microsoft.EntityFrameworkCore;
using SuperShop.Models.Data;

namespace SuperShop.ServiceCollectionExtensions.ConfigurationExtensions
{
    public static class DatabaseConnectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CORE");
            var readOnlyConnectionString = configuration.GetConnectionString("CORE_READONLY");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            return service
                .AddDbContext<FakeDexContext>(options =>
                    options.UseMySql(connectionString, serverVersion));
        }
    }
}