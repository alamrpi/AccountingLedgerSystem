using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AccountingLedgerSystem.Application.Features.Queries.Reports
{
    public class GetTrialBalanceQuery : IRequest<List<TrialBalanceDto>> { }

    //implement GetTrialBalanceQueryHandler
    public class GetTrialBalanceQueryHandler : IRequestHandler<GetTrialBalanceQuery, List<TrialBalanceDto>>
    {
        private readonly ITrialBalanceRepository _repository;
        private readonly IMapper _mapper;

        public GetTrialBalanceQueryHandler(ITrialBalanceRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<TrialBalanceDto>> Handle(GetTrialBalanceQuery request, CancellationToken cancellationToken)
        {
            var trialBalance = await _repository.GetTrialBalanceAsync();
            return _mapper.Map<List<TrialBalanceDto>>(trialBalance);
        }
    }

}
