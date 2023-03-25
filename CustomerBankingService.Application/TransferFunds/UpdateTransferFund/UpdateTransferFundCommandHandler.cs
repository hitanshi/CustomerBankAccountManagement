using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.UpdateTransferFund
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateTransferFundCommandHandler : IRequestHandler<UpdateTransferFundCommand>
    {
        private readonly ITransferFundRepository _transferFundRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateTransferFundCommandHandler(ITransferFundRepository transferFundRepository)
        {
            _transferFundRepository = transferFundRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateTransferFundCommand request, CancellationToken cancellationToken)
        {
            var existingTransferFund = await _transferFundRepository.FindByIdAsync(request.Id, cancellationToken);
            existingTransferFund.CreditorAccountNumber = request.CreditorAccountNumber;
            existingTransferFund.DebitorAccountNumber = request.DebitorAccountNumber;
            existingTransferFund.TransferAmount = request.TransferAmount;
            return Unit.Value;
        }
    }
}