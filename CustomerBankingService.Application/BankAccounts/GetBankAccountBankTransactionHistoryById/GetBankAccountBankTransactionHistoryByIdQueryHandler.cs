using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Entities;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.GetBankAccountBankTransactionHistoryById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankAccountBankTransactionHistoryByIdQueryHandler : IRequestHandler<GetBankAccountBankTransactionHistoryByIdQuery, BankAccountBankTransactionHistoryDto>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankAccountBankTransactionHistoryByIdQueryHandler(IBankAccountRepository bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<BankAccountBankTransactionHistoryDto> Handle(GetBankAccountBankTransactionHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _bankAccountRepository.FindByIdAsync(request.BankAccountId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(BankAccount)} of Id '{request.BankAccountId}' could not be found");
            }

            var element = aggregateRoot.BankTransactionHistories.FirstOrDefault(p => p.Id == request.Id);
            return element == null ? null : element.MapToBankAccountBankTransactionHistoryDto(_mapper);
        }
    }
}