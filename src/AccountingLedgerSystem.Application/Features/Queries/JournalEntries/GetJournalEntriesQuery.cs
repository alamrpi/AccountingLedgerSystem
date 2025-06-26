using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Interfaces;
using AccountingLedgerSystem.Shared.Dto;
using AutoMapper;
using MediatR;

namespace AccountingLedgerSystem.Application.Features.Queries.JournalEntries
{
    public record GetJournalEntriesQuery : IRequest<PaginatedResult<JournalEntryDto>> { }

    public class GetJournalEntriesQueryHandler : IRequestHandler<GetJournalEntriesQuery, PaginatedResult<JournalEntryDto>>
    {
        private readonly IJournalEntryRepository _repository;
        private readonly IMapper _mapper;

        public GetJournalEntriesQueryHandler(IJournalEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<JournalEntryDto>> Handle(GetJournalEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _repository.GetPaginatedAsync(1, 50);
            if (entries == null || entries.Items == null || !entries.Items.Any())
            {
                return new PaginatedResult<JournalEntryDto>
                {
                    Items = new List<JournalEntryDto>(),
                    TotalCount = 0,
                    PageNumber = 1,
                    PageSize = 50
                };
            }
            return new PaginatedResult<JournalEntryDto>
            {
                Items = _mapper.Map<List<JournalEntryDto>>(entries.Items.ToList()),
                TotalCount = entries.TotalCount,
                PageNumber = entries.PageNumber,
                PageSize = entries.PageSize,
            };
        }
    }
}
