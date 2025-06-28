using AccountingLedgerSystem.Application.DTOs;
using FluentValidation;

namespace AccountingLedgerSystem.Application.Validators
{
    internal class JournalEntryLineValidator : AbstractValidator<JournalEntryLineRequestDto>
    {
        public JournalEntryLineValidator()
        {
            RuleFor(x => x.AccountId).GreaterThan(0);
            RuleFor(x => x.Debit).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Credit).GreaterThanOrEqualTo(0);
        }
    }
}
