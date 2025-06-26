namespace AccountingLedgerSystem.Application.DTOs
{
    public class JournalEntryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        //public IEnumerable<JournalEntryLineDto> JournalEntryLines { get; set; } = new List<JournalEntryLineDto>();
    }
}

