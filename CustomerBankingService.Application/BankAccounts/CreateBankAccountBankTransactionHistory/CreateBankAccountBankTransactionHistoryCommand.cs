using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.CreateBankAccountBankTransactionHistory
{
    public class CreateBankAccountBankTransactionHistoryCommand : IRequest<int>, ICommand
    {
        public int BankAccountId { get; set; }

        public decimal AmountDebited { get; set; }

        public decimal AmountCredited { get; set; }

    }
}