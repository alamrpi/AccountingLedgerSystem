namespace AccountingLedgerSystem.Shared.Dto
{
    public class JournalEntryWithLinesDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Amount => Debit > 0 ? Debit : Credit;
    }
}
