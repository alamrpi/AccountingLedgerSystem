using AccountingLedgerSystem.Application.DTOs;
using AccountingLedgerSystem.Core.Entities;
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
        }
    }
}
