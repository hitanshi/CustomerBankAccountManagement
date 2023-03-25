using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace CustomerBankingService.Infrastructure.Persistence.Configurations
{
    public class TransferFundConfiguration : IEntityTypeConfiguration<TransferFund>
    {
        public void Configure(EntityTypeBuilder<TransferFund> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreditorAccountNumber)
                .IsRequired();

            builder.Property(x => x.DebitorAccountNumber)
                .IsRequired();

            builder.Property(x => x.TransferAmount)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}