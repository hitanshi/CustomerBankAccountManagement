using System.Collections.Generic;
using CustomerBankingService.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace CustomerBankingService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class BankTransactionHistory
    {
        public int Id { get; set; }

        public int BankAccountId { get; set; }

        public decimal AmountDebited { get; set; }

        public decimal AmountCredited { get; set; }

        public virtual BankAccount BankAccount { get; set; }
    }
}