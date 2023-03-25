using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.GetTransferFundById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTransferFundByIdQueryHandler : IRequestHandler<GetTransferFundByIdQuery, TransferFundDto>
    {
        private readonly ITransferFundRepository _transferFundRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetTransferFundByIdQueryHandler(ITransferFundRepository transferFundRepository, IMapper mapper)
        {
            _transferFundRepository = transferFundRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<TransferFundDto> Handle(GetTransferFundByIdQuery request, CancellationToken cancellationToken)
        {
            var transferFund = await _transferFundRepository.FindByIdAsync(request.Id, cancellationToken);
            return transferFund.MapToTransferFundDto(_mapper);
        }
    }
}