using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Entities;
using AccountingLedgerSystem.Shared.Dto;
using AutoMapper;

namespace AccountingLedgerSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<AccountCreateRequestDto, Account>().ReverseMap();
            CreateMap<JournalEntryDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntryLineDto, JournalEntryLine>().ReverseMap();
            CreateMap<JournalEntryRequestDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntryLineRequestDto, JournalEntryLine>().ReverseMap();
            CreateMap<TrialBalanceDto, TrialBalanceItem>().ReverseMap();
        }
    }
}
