using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.CheckBalance
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CheckBalanceHandler : IRequestHandler<CheckBalance, decimal>
    {
        private readonly IBankAccountRepository bankAccountRepository;

        [IntentManaged(Mode.Ignore)]
        public CheckBalanceHandler(IBankAccountRepository bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<decimal> Handle(CheckBalance request, CancellationToken cancellationToken)
        {
            var bankAccountDetails = await bankAccountRepository.FindAsync(x => x.Id == request.AccountNumber, cancellationToken);
            return bankAccountDetails.CurrentBalance;
        }
    }
}