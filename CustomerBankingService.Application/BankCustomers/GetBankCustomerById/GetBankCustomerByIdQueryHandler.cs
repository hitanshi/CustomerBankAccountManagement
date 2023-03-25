using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerBankingService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers.GetBankCustomerById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankCustomerByIdQueryHandler : IRequestHandler<GetBankCustomerByIdQuery, BankCustomerDto>
    {
        private readonly IBankCustomerRepository _bankCustomerRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetBankCustomerByIdQueryHandler(IBankCustomerRepository bankCustomerRepository, IMapper mapper)
        {
            _bankCustomerRepository = bankCustomerRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<BankCustomerDto> Handle(GetBankCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var bankCustomer = await _bankCustomerRepository.FindByIdAsync(request.Id, cancellationToken);
            return bankCustomer.MapToBankCustomerDto(_mapper);
        }
    }
}