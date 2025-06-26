using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AccountingLedgerSystem.Application.Features.Queries.JournalEntries
{
    public record GetJournalEntriesQuery : IRequest<List<JournalEntryDto>> { }

    public class GetJournalEntriesQueryHandler : IRequestHandler<GetJournalEntriesQuery, List<JournalEntryDto>>
    {
        private readonly IJournalEntryRepository _repository;
        private readonly IMapper _mapper;

        public GetJournalEntriesQueryHandler(IJournalEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<JournalEntryDto>> Handle(GetJournalEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _repository.GetPaginatedAsync(1, 50);
            return _mapper.Map<List<JournalEntryDto>>(entries);
        }
    }
}
