using AccountingLedgerSystem.Core.Entities.Common;
using AccountingLedgerSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
