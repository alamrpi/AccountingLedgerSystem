using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
