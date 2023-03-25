using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers.UpdateBankCustomer
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateBankCustomerCommandHandler : IRequestHandler<UpdateBankCustomerCommand>
    {
        private readonly IBankCustomerRepository _bankCustomerRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateBankCustomerCommandHandler(IBankCustomerRepository bankCustomerRepository)
        {
            _bankCustomerRepository = bankCustomerRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateBankCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingBankCustomer = await _bankCustomerRepository.FindByIdAsync(request.Id, cancellationToken);
            existingBankCustomer.FirstName = request.FirstName;
            existingBankCustomer.LastName = request.LastName;
            existingBankCustomer.IdNumber = request.IdNumber;
            existingBankCustomer.Gender = request.Gender;
            return Unit.Value;
        }
    }
}