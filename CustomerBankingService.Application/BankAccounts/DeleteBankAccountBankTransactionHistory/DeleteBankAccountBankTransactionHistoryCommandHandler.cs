using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Entities;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.DeleteBankAccountBankTransactionHistory
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteBankAccountBankTransactionHistoryCommandHandler : IRequestHandler<DeleteBankAccountBankTransactionHistoryCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteBankAccountBankTransactionHistoryCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteBankAccountBankTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _bankAccountRepository.FindByIdAsync(request.BankAccountId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(BankAccount)} of Id '{request.BankAccountId}' could not be found");
            }

            var element = aggregateRoot.BankTransactionHistories.FirstOrDefault(p => p.Id == request.Id);
            if (element == null)
            {
                throw new InvalidOperationException($"{nameof(BankTransactionHistory)} of Id '{request.Id}' could not be found associated with {nameof(BankAccount)} of Id '{request.BankAccountId}'");
            }
            aggregateRoot.BankTransactionHistories.Remove(element);
            return Unit.Value;
        }
    }
}