using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.GetBankAccountById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankAccountByIdQueryHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccountDto>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankAccountByIdQueryHandler(IBankAccountRepository bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<BankAccountDto> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountRepository.FindByIdAsync(request.Id, cancellationToken);
            return bankAccount.MapToBankAccountDto(_mapper);
        }
    }
}