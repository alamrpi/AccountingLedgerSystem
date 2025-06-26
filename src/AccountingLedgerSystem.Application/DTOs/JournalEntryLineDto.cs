using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
