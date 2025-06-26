using AccountingLedgerSystem.Core.Entities.Common;

namespace AccountingLedgerSystem.Core.Entities
{
    public class JournalEntryLine : BaseEntity
    {
        public int AccountId { get; set; }
        public int JournalEntryId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        public JournalEntry JournalEntry { get; set; } = new JournalEntry();

        public Account Account { get; set; } = new Account();
    }
}
