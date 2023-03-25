using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds
{
    public static class TransferFundDtoMappingExtensions
    {
        public static TransferFundDto MapToTransferFundDto(this TransferFund projectFrom, IMapper mapper)
        {
            return mapper.Map<TransferFundDto>(projectFrom);
        }

        public static List<TransferFundDto> MapToTransferFundDtoList(this IEnumerable<TransferFund> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToTransferFundDto(mapper)).ToList();
        }
    }
}