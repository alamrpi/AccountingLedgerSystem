using AccountingLedgerSystem.Application.DTOs;
using FluentValidation;

namespace AccountingLedgerSystem.Application.Validators
{
    public class JournalEntryValidator : AbstractValidator<JournalEntryRequestDto>
    {
        public JournalEntryValidator()
        {
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(255);
            RuleFor(x => x.JournalEntryLines).NotEmpty().Must(items =>
                items.Sum(i => i.Debit > 0 ? i.Debit : -i.Credit) == 0)
                .WithMessage("Total debits must equal total credits");
            RuleForEach(x => x.JournalEntryLines).SetValidator(new JournalEntryLineValidator());
        }
    }
}
