using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts
{
    public static class BankAccountBankTransactionHistoryDtoMappingExtensions
    {
        public static BankAccountBankTransactionHistoryDto MapToBankAccountBankTransactionHistoryDto(this BankTransactionHistory projectFrom, IMapper mapper)
        {
            return mapper.Map<BankAccountBankTransactionHistoryDto>(projectFrom);
        }

        public static List<BankAccountBankTransactionHistoryDto> MapToBankAccountBankTransactionHistoryDtoList(this IEnumerable<BankTransactionHistory> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToBankAccountBankTransactionHistoryDto(mapper)).ToList();
        }
    }
}