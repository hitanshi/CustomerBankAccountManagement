using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.DeleteTransferFund
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteTransferFundCommandHandler : IRequestHandler<DeleteTransferFundCommand>
    {
        private readonly ITransferFundRepository _transferFundRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteTransferFundCommandHandler(ITransferFundRepository transferFundRepository)
        {
            _transferFundRepository = transferFundRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteTransferFundCommand request, CancellationToken cancellationToken)
        {
            var existingTransferFund = await _transferFundRepository.FindByIdAsync(request.Id, cancellationToken);
            _transferFundRepository.Remove(existingTransferFund);
            return Unit.Value;
        }
    }
}