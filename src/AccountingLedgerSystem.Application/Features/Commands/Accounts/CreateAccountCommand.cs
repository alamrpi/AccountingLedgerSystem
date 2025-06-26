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

namespace AccountingLedgerSystem.Application.Features.Commands.Accounts
{
    public record CreateAccountCommand(AccountCreateRequestDto AccountDto) : IRequest<int>;

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request.AccountDto);
            return await _repository.CreateAsync(account);
        }
    }


}
