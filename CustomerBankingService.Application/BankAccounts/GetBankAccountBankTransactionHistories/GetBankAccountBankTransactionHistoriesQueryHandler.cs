using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Entities;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.GetBankAccountBankTransactionHistories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankAccountBankTransactionHistoriesQueryHandler : IRequestHandler<GetBankAccountBankTransactionHistoriesQuery, List<BankAccountBankTransactionHistoryDto>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankAccountBankTransactionHistoriesQueryHandler(IBankAccountRepository bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<BankAccountBankTransactionHistoryDto>> Handle(GetBankAccountBankTransactionHistoriesQuery request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _bankAccountRepository.FindByIdAsync(request.BankAccountId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(BankAccount)} of Id '{request.BankAccountId}' could not be found");
            }
            return aggregateRoot.BankTransactionHistories.MapToBankAccountBankTransactionHistoryDtoList(_mapper);
        }
    }
}