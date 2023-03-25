using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.GetBankAccountBankTransactionHistoryById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetBankAccountBankTransactionHistoryByIdQueryValidator : AbstractValidator<GetBankAccountBankTransactionHistoryByIdQuery>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public GetBankAccountBankTransactionHistoryByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}