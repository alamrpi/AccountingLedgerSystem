using System.ComponentModel.DataAnnotations;

namespace AccountingLedgerSystem.Core.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
