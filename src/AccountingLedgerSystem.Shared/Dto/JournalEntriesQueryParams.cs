using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Shared.Dto
{
    public class JournalEntriesQueryParams
    {
        public int PageSize { get; set; } = 10; // Default page size
        public int PageNumber { get; set; } = 1; // Default page number
        public string SortField { get; set; } = "Date"; // Default sort field
        public string SortDirection { get; set; } = "asc"; // Default sort direction
        public DateTime? Date { get; set; }
    }
}
