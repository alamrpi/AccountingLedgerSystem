using AccountingLedgerSystem.Core.Entities.Common;
using AccountingLedgerSystem.Core.Enums;

namespace AccountingLedgerSystem.Core.Entities
{
    public class Account : BaseEntity
    {

        public string Name { get; set; } = null!;
        public AccountType Type { get; set; }
        public string? Description { get; set; }

        public ICollection<JournalEntryLine> JournalEntryLines { get; set; } = new List<JournalEntryLine>();
    }
}
