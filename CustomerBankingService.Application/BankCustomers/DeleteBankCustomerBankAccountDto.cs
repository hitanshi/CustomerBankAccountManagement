using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers
{

    public class DeleteBankCustomerBankAccountDto
    {
        public DeleteBankCustomerBankAccountDto()
        {
        }

        public static DeleteBankCustomerBankAccountDto Create(
            int customerId,
            decimal currentBalance,
            int id)
        {
            return new DeleteBankCustomerBankAccountDto
            {
                CustomerId = customerId,
                CurrentBalance = currentBalance,
                Id = id,
            };
        }

        public int CustomerId { get; set; }

        public decimal CurrentBalance { get; set; }

        public int Id { get; set; }

    }
}