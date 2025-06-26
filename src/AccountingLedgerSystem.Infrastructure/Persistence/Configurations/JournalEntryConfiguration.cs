using AccountingLedgerSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Configurations
{
    public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.Property(j => j.Description).IsRequired().HasMaxLength(200);
            builder.Property(j => j.Date).IsRequired();
        }
    }
}
