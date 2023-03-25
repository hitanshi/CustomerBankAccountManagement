using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers
{
    public static class BankCustomerDtoMappingExtensions
    {
        public static BankCustomerDto MapToBankCustomerDto(this BankCustomer projectFrom, IMapper mapper)
        {
            return mapper.Map<BankCustomerDto>(projectFrom);
        }

        public static List<BankCustomerDto> MapToBankCustomerDtoList(this IEnumerable<BankCustomer> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToBankCustomerDto(mapper)).ToList();
        }
    }
}