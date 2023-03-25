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

namespace CustomerBankingService.Application.BankAccounts.CreateBankAccount
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, int>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<int> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var newBankAccount = new BankAccount
            {
                CustomerId = request.CustomerId,
                BankAccountTypeId = request.BankAccountTypeId,
                CurrentBalance = request.CurrentBalance,
            };

            _bankAccountRepository.Add(newBankAccount);
            await _bankAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newBankAccount.Id;
        }
    }
}