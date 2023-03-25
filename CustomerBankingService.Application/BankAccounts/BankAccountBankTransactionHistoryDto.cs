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

    public class BankAccountBankTransactionHistoryDto : IMapFrom<BankTransactionHistory>
    {
        public BankAccountBankTransactionHistoryDto()
        {
        }

        public static BankAccountBankTransactionHistoryDto Create(
            int id,
            int bankAccountId,
            decimal amountDebited,
            decimal amountCredited)
        {
            return new BankAccountBankTransactionHistoryDto
            {
                Id = id,
                BankAccountId = bankAccountId,
                AmountDebited = amountDebited,
                AmountCredited = amountCredited,
            };
        }

        public int Id { get; set; }

        public int BankAccountId { get; set; }

        public decimal AmountDebited { get; set; }

        public decimal AmountCredited { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BankTransactionHistory, BankAccountBankTransactionHistoryDto>();
        }
    }
}