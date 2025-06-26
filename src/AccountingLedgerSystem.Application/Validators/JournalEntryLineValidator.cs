using AccountingLedgerSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Application.Validators
{
    internal class JournalEntryLineValidator : AbstractValidator<JournalEntryLineDto>
    {
        public JournalEntryLineValidator()
        {
            RuleFor(x => x.AccountId).GreaterThan(0);
        }
    }
}
