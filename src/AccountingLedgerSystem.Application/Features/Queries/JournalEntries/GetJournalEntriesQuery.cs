using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Shared.Dto;
using AutoMapper;
using MediatR;

namespace AccountingLedgerSystem.Application.Features.Queries.JournalEntries
{
    public record GetJournalEntriesQuery(int PageNumber, int PageSize) : IRequest<PaginatedResult<JournalEntryWithLinesDto>> { }

    public class GetJournalEntriesQueryHandler : IRequestHandler<GetJournalEntriesQuery, PaginatedResult<JournalEntryWithLinesDto>>
    {
        private readonly IJournalEntryRepository _repository;
        private readonly IMapper _mapper;

        public GetJournalEntriesQueryHandler(IJournalEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<JournalEntryWithLinesDto>> Handle(GetJournalEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _repository.GetPaginatedAsync(request.PageNumber, request.PageSize);
            if (entries == null || entries.Items == null || !entries.Items.Any())
            {
                return new PaginatedResult<JournalEntryWithLinesDto>
                {
                    Items = new List<JournalEntryWithLinesDto>(),
                    TotalCount = 0,
                    PageNumber = 1,
                    PageSize = 50
                };
            }
            return entries;
        }
    }
}
