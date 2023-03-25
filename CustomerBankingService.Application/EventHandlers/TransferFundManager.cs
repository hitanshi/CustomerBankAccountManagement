using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Application.Common.Models;
using CustomerBankingService.Domain.Entities;
using CustomerBankingService.Domain.Events;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.MediatR.DomainEvents.AggregateManager", Version = "1.0")]

namespace CustomerBankingService.Application.EventHandlers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class TransferFundManager : INotificationHandler<DomainEventNotification<TransferFundStarted>>
    {
        private readonly IBankAccountRepository bankAccountRepository;

        public TransferFundManager(IBankAccountRepository bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task Handle(DomainEventNotification<TransferFundStarted> notification, CancellationToken cancellationToken)
        {

            throw new NotImplementedException("Implement your handler logic here...");
        }
    }
}