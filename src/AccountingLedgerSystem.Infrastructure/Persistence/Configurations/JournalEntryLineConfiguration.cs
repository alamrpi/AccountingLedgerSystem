using AccountingLedgerSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Configurations
{
    public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
        {
            builder.Property(j => j.Debit).HasColumnType("decimal(18,2)");
            builder.Property(j => j.Credit).HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(j => j.JournalEntry)
                .WithMany(j => j.JournalEntryLines)
                .HasForeignKey(j => j.JournalEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(j => j.Account)
                .WithMany(a => a.JournalEntryLines)
                .HasForeignKey(j => j.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
