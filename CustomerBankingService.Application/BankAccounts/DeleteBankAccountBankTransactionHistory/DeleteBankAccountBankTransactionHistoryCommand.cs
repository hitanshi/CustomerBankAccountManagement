using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.DeleteBankAccountBankTransactionHistory
{
    public class DeleteBankAccountBankTransactionHistoryCommand : IRequest, ICommand
    {
        public int BankAccountId { get; set; }

        public int Id { get; set; }

    }
}