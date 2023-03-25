using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.DeleteBankAccount
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteBankAccountCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var existingBankAccount = await _bankAccountRepository.FindByIdAsync(request.Id, cancellationToken);
            _bankAccountRepository.Remove(existingBankAccount);
            return Unit.Value;
        }
    }
}