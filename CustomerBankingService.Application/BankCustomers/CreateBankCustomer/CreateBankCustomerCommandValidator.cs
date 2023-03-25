using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace CustomerBankingService.Application.BankCustomers.CreateBankCustomer
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateBankCustomerCommandValidator : AbstractValidator<CreateBankCustomerCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateBankCustomerCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.FirstName)
                .NotNull();

            RuleFor(v => v.LastName)
                .NotNull();

            RuleFor(v => v.IdNumber)
                .NotNull();

            RuleFor(v => v.Gender)
                .NotNull();

        }
    }
}