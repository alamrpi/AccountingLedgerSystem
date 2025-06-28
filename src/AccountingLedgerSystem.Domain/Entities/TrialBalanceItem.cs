namespace AccountingLedgerSystem.Core.Entities
{
    public class TrialBalanceItem
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal DebitTotal { get; set; }
        public decimal CreditTotal { get; set; }
        public decimal Balance { get; set; }
        public string BalanceType { get; set; }
        public string FinancialStatement { get; set; } = string.Empty;
    }
}
