using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace CustomerBankingService.Application.TransferFunds.GetTransferFunds
{
    public class GetTransferFundsQuery : IRequest<List<TransferFundDto>>, IQuery
    {
    }
}