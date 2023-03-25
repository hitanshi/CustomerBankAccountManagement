using System;
using System.Collections.Generic;
using CustomerBankingService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.GetBankAccounts
{
    public class GetBankAccountsQuery : IRequest<List<BankAccountDto>>, IQuery
    {
    }
}