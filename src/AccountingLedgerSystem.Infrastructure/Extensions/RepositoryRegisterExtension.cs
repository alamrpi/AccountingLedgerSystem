using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingLedgerSystem.Infrastructure.Extensions
{
    public static class RepositoryRegisterExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
            services.AddScoped<ITrialBalanceRepository, TrialBalanceRepository>();
            return services;
        }
    }
}
