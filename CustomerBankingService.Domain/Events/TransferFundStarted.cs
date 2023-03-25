using System;
using System.Collections.Generic;
using CustomerBankingService.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.DomainEvents.DomainEvent", Version = "1.0")]

namespace CustomerBankingService.Domain.Events
{
    public class TransferFundStarted : DomainEvent
    {
        public TransferFundStarted(long debitorAccountNumber, decimal transferAmount)
        {
            DebitorAccountNumber = debitorAccountNumber;
            TransferAmount = transferAmount;
        }

        public long DebitorAccountNumber { get; }

        public decimal TransferAmount { get; }
    }
}