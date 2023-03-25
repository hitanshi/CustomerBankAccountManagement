using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerBankingService.Application.Common.Mappings;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds
{

    public class TransferFundDto : IMapFrom<TransferFund>
    {
        public TransferFundDto()
        {
        }

        public static TransferFundDto Create(
            int id,
            long creditorAccountNumber,
            long debitorAccountNumber,
            decimal transferAmount)
        {
            return new TransferFundDto
            {
                Id = id,
                CreditorAccountNumber = creditorAccountNumber,
                DebitorAccountNumber = debitorAccountNumber,
                TransferAmount = transferAmount,
            };
        }

        public int Id { get; set; }

        public long CreditorAccountNumber { get; set; }

        public long DebitorAccountNumber { get; set; }

        public decimal TransferAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TransferFund, TransferFundDto>();
        }
    }
}