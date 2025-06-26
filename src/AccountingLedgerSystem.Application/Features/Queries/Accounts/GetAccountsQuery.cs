using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Application.Features.Queries.Accounts
{
    public record GetAccountsQuery : IRequest<List<AccountDto>> { }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<AccountDto>>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAllAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }
    }

}
