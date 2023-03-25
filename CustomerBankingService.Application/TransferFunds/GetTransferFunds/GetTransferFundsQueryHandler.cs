using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.GetTransferFunds
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTransferFundsQueryHandler : IRequestHandler<GetTransferFundsQuery, List<TransferFundDto>>
    {
        private readonly ITransferFundRepository _transferFundRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetTransferFundsQueryHandler(ITransferFundRepository transferFundRepository, IMapper mapper)
        {
            _transferFundRepository = transferFundRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<TransferFundDto>> Handle(GetTransferFundsQuery request, CancellationToken cancellationToken)
        {
            var transferFunds = await _transferFundRepository.FindAllAsync(cancellationToken);
            return transferFunds.MapToTransferFundDtoList(_mapper);
        }
    }
}