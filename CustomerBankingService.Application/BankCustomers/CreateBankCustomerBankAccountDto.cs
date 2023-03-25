using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers
{

    public class CreateBankCustomerBankAccountDto
    {
        public CreateBankCustomerBankAccountDto()
        {
        }

        public static CreateBankCustomerBankAccountDto Create(
            decimal currentBalance)
        {
            return new CreateBankCustomerBankAccountDto
            {
                CurrentBalance = currentBalance,
            };
        }

        public decimal CurrentBalance { get; set; }

    }
}