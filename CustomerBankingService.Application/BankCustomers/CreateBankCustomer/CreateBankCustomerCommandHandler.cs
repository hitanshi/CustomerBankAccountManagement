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

namespace CustomerBankingService.Application.BankCustomers.CreateBankCustomer
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBankCustomerCommandHandler : IRequestHandler<CreateBankCustomerCommand, int>
    {
        private readonly IBankCustomerRepository _bankCustomerRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateBankCustomerCommandHandler(IBankCustomerRepository bankCustomerRepository)
        {
            _bankCustomerRepository = bankCustomerRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<int> Handle(CreateBankCustomerCommand request, CancellationToken cancellationToken)
        {
            var newBankCustomer = new BankCustomer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                Gender = request.Gender,
                DepositAmount = request.DepositAmount,
            };

            _bankCustomerRepository.Add(newBankCustomer);
            await _bankCustomerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newBankCustomer.Id;
        }
    }
}