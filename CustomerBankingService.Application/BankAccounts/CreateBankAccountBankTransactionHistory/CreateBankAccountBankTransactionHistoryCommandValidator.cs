using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.CreateBankAccountBankTransactionHistory
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBankAccountBankTransactionHistoryCommandValidator : AbstractValidator<CreateBankAccountBankTransactionHistoryCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateBankAccountBankTransactionHistoryCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}