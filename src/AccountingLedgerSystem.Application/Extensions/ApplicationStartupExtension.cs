using AccountingLedgerSystem.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingLedgerSystem.Application.Extensions
{
    public static class ApplicationStartupExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // Example: services.AddScoped<IAccountService, AccountService>();
            services.AddCoreServices();
            return services;
        }
     
    }
}
