using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace CustomerBankingService.Application.BankAccounts.CheckBalance
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CheckBalanceValidator : AbstractValidator<CheckBalance>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CheckBalanceValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.AccountNumber)
                .NotEmpty();

        }
    }
}