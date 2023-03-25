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
    public class BankAccount : IHasDomainEvent
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal CurrentBalance { get; set; }

        public int BankAccountTypeId { get; set; }

        public virtual BankCustomer Customer { get; set; }

        public virtual BankAccountType BankAccountType { get; set; }

        public virtual ICollection<BankTransactionHistory> BankTransactionHistories { get; set; } = new List<BankTransactionHistory>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}