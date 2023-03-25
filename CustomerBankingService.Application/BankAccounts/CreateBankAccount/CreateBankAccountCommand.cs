using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.CreateBankAccount
{
    public class CreateBankAccountCommand : IRequest<int>, ICommand
    {
        public int CustomerId { get; set; }

        public int BankAccountTypeId { get; set; }

        public decimal CurrentBalance { get; set; }

    }
}