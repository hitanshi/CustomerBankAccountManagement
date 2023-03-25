using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace CustomerBankingService.Infrastructure.Persistence.Configurations
{
    public class BankAccountTypeConfiguration : IEntityTypeConfiguration<BankAccountType>
    {
        public void Configure(EntityTypeBuilder<BankAccountType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}