using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.UpdateBankAccount
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var existingBankAccount = await _bankAccountRepository.FindByIdAsync(request.Id, cancellationToken);
            existingBankAccount.CustomerId = request.CustomerId;
            existingBankAccount.BankAccountTypeId = request.BankAccountTypeId;
            existingBankAccount.CurrentBalance = request.CurrentBalance;
            return Unit.Value;
        }
    }
}