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
    public static class BankAccountDtoMappingExtensions
    {
        public static BankAccountDto MapToBankAccountDto(this BankAccount projectFrom, IMapper mapper)
        {
            return mapper.Map<BankAccountDto>(projectFrom);
        }

        public static List<BankAccountDto> MapToBankAccountDtoList(this IEnumerable<BankAccount> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToBankAccountDto(mapper)).ToList();
        }
    }
}