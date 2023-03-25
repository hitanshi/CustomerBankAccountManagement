using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.UpdateBankAccount
{
    public class UpdateBankAccountCommand : IRequest, ICommand
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int BankAccountTypeId { get; set; }

        public decimal CurrentBalance { get; set; }

    }
}