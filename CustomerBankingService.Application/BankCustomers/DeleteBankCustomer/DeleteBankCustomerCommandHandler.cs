using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers.DeleteBankCustomer
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteBankCustomerCommandHandler : IRequestHandler<DeleteBankCustomerCommand>
    {
        private readonly IBankCustomerRepository _bankCustomerRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteBankCustomerCommandHandler(IBankCustomerRepository bankCustomerRepository)
        {
            _bankCustomerRepository = bankCustomerRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteBankCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingBankCustomer = await _bankCustomerRepository.FindByIdAsync(request.Id, cancellationToken);
            _bankCustomerRepository.Remove(existingBankCustomer);
            return Unit.Value;
        }
    }
}