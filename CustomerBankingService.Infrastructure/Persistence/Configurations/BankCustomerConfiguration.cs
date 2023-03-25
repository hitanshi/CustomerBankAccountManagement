using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace CustomerBankingService.Infrastructure.Persistence.Configurations
{
    public class BankCustomerConfiguration : IEntityTypeConfiguration<BankCustomer>
    {
        public void Configure(EntityTypeBuilder<BankCustomer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property(x => x.IdNumber)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.DepositAmount)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}