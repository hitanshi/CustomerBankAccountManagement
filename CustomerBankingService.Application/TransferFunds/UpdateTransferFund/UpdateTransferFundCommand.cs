using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.UpdateTransferFund
{
    public class UpdateTransferFundCommand : IRequest, ICommand
    {
        public int Id { get; set; }

        public long CreditorAccountNumber { get; set; }

        public long DebitorAccountNumber { get; set; }

        public decimal TransferAmount { get; set; }

    }
}