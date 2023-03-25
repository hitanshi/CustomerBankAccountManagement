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

namespace CustomerBankingService.Application.BankAccounts.GetBankAccounts
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankAccountsQueryHandler : IRequestHandler<GetBankAccountsQuery, List<BankAccountDto>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankAccountsQueryHandler(IBankAccountRepository bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<BankAccountDto>> Handle(GetBankAccountsQuery request, CancellationToken cancellationToken)
        {
            var bankAccounts = await _bankAccountRepository.FindAllAsync(cancellationToken);
            return bankAccounts.MapToBankAccountDtoList(_mapper);
        }
    }
}