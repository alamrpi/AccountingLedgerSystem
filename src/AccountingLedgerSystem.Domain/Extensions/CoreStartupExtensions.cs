using Microsoft.Extensions.DependencyInjection;

namespace AccountingLedgerSystem.Core.Extensions
{
    public static class CoreStartupExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {

            return services;
        }
    }
}
