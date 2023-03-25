using System.Collections.Generic;
using CustomerBankingService.Domain.Common;
using CustomerBankingService.Domain.Events;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace CustomerBankingService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class TransferFund : IHasDomainEvent
    {
        public TransferFund()
        {
            DomainEvents.Add(new TransferFundStarted(DebitorAccountNumber, TransferAmount));
        }
        public int Id { get; set; }

        public long CreditorAccountNumber { get; set; }

        public long DebitorAccountNumber { get; set; }

        public decimal TransferAmount { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}