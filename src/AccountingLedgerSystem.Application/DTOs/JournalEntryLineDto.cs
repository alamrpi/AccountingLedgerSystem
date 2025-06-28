namespace AccountingLedgerSystem.Application.DTOs
{
    public class JournalEntryLineDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int JournalEntryId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
