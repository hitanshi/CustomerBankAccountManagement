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

namespace CustomerBankingService.Application.BankCustomers.GetBankCustomers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankCustomersQueryHandler : IRequestHandler<GetBankCustomersQuery, List<BankCustomerDto>>
    {
        private readonly IBankCustomerRepository _bankCustomerRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankCustomersQueryHandler(IBankCustomerRepository bankCustomerRepository, IMapper mapper)
        {
            _bankCustomerRepository = bankCustomerRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<BankCustomerDto>> Handle(GetBankCustomersQuery request, CancellationToken cancellationToken)
        {
            var bankCustomers = await _bankCustomerRepository.FindAllAsync(cancellationToken);
            return bankCustomers.MapToBankCustomerDtoList(_mapper);
        }
    }
}