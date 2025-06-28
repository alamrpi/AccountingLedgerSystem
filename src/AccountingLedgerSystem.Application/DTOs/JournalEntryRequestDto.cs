namespace AccountingLedgerSystem.Application.DTOs
{
    public class JournalEntryRequestDto
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public IEnumerable<JournalEntryLineRequestDto> JournalEntryLines { get; set; } = new List<JournalEntryLineRequestDto>();
    }

    public class JournalEntryLineRequestDto
    {
        public int AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
