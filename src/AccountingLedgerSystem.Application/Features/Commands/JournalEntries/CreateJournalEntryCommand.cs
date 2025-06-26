using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Application.Features.Commands.JournalEntries
{
    public record CreateJournalEntryCommand(JournalEntryRequestDto JournalEntry) : IRequest<int>;


    public class CreateJournalEntryCommandHandler : IRequestHandler<CreateJournalEntryCommand, int>
    {
        private readonly IJournalEntryRepository _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateJournalEntryCommandHandler(
            IJournalEntryRepository repository,
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            _repository = repository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateJournalEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = _mapper.Map<JournalEntry>(request.JournalEntry);

            // Validate all accounts exist
            //foreach (var item in entry.JournalEntryLines)
            //{
            //    var account = await _accountRepository.GetByIdAsync(item.AccountId);
            //    if (account == null)
            //        throw new KeyNotFoundException($"Account with ID {item.AccountId} not found");
            //}

            return await _repository.CreateAsync(entry);
        }
    }

}
