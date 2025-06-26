using AccountingLedgerSystem.Core.Enums;

namespace AccountingLedgerSystem.Application.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
