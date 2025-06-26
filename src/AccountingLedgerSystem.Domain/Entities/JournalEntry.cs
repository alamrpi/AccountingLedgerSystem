using AccountingLedgerSystem.Core.Entities.Common;

namespace AccountingLedgerSystem.Core.Entities
{
    public class JournalEntry : BaseEntity
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public ICollection<JournalEntryLine> JournalEntryLines { get; set; } = new List<JournalEntryLine>();
    }
}
