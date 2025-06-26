using AccountingLedgerSystem.Core.Extensions;
using AccountingLedgerSystem.Infrastructure.Data;
using AccountingLedgerSystem.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingLedgerSystem.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your infrastructure services here
            // Example: services.AddDbContext<ApplicationDbContext>(options => ...);
            // Return the service collection to allow for method chaining
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddRepositories();
            services.AddCoreServices();

            return services;
        }
    }
}
