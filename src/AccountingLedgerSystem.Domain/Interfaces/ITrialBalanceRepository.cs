using AccountingLedgerSystem.Core.Entities;

namespace AccountingLedgerSystem.Core.Interfaces
{
    public interface ITrialBalanceRepository
    {
        /// <summary>
        /// Retrieves the trial balance for the current period.
        /// </summary>
        /// <returns>A list of trial balance entries.</returns>
        Task<List<TrialBalanceItem>> GetTrialBalanceAsync(DateTime? asOfDate = null, bool includeZeroBalances = false);


    }
}
