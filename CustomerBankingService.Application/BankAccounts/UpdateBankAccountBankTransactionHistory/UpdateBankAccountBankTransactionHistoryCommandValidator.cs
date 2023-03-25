using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.UpdateBankAccountBankTransactionHistory
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateBankAccountBankTransactionHistoryCommandValidator : AbstractValidator<UpdateBankAccountBankTransactionHistoryCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateBankAccountBankTransactionHistoryCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}