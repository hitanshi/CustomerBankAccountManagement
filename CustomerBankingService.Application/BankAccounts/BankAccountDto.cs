using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerBankingService.Application.Common.Mappings;
using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts
{

    public class BankAccountDto : IMapFrom<BankAccount>
    {
        public BankAccountDto()
        {
        }

        public static BankAccountDto Create(
            int id,
            int customerId,
            int bankAccountTypeId,
            decimal currentBalance)
        {
            return new BankAccountDto
            {
                Id = id,
                CustomerId = customerId,
                BankAccountTypeId = bankAccountTypeId,
                CurrentBalance = currentBalance,
            };
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int BankAccountTypeId { get; set; }

        public decimal CurrentBalance { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BankAccount, BankAccountDto>();
        }
    }
}