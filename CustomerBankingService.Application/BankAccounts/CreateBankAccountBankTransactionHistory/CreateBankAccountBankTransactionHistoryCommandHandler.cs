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

namespace CustomerBankingService.Application.BankAccounts.CreateBankAccountBankTransactionHistory
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBankAccountBankTransactionHistoryCommandHandler : IRequestHandler<CreateBankAccountBankTransactionHistoryCommand, int>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateBankAccountBankTransactionHistoryCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<int> Handle(CreateBankAccountBankTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _bankAccountRepository.FindByIdAsync(request.BankAccountId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(BankAccount)} of Id '{request.BankAccountId}' could not be found");
            }
            var newBankTransactionHistory = new BankTransactionHistory
            {
                BankAccountId = request.BankAccountId,
                AmountDebited = request.AmountDebited,
                AmountCredited = request.AmountCredited,
            };

            aggregateRoot.BankTransactionHistories.Add(newBankTransactionHistory);
            await _bankAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newBankTransactionHistory.Id;
        }
    }
}