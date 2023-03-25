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

namespace CustomerBankingService.Application.TransferFunds.CreateTransferFund
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateTransferFundCommandHandler : IRequestHandler<CreateTransferFundCommand, int>
    {
        private readonly ITransferFundRepository _transferFundRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateTransferFundCommandHandler(ITransferFundRepository transferFundRepository)
        {
            _transferFundRepository = transferFundRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<int> Handle(CreateTransferFundCommand request, CancellationToken cancellationToken)
        {
            var newTransferFund = new TransferFund
            {
                CreditorAccountNumber = request.CreditorAccountNumber,
                DebitorAccountNumber = request.DebitorAccountNumber,
                TransferAmount = request.TransferAmount,
            };

            _transferFundRepository.Add(newTransferFund);
            await _transferFundRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newTransferFund.Id;
        }
    }
}