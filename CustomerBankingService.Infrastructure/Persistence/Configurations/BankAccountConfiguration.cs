using CustomerBankingService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace CustomerBankingService.Infrastructure.Persistence.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.BankAccountTypeId)
                .IsRequired();

            builder.Property(x => x.CurrentBalance)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BankAccountType)
                .WithMany()
                .HasForeignKey(x => x.BankAccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(x => x.BankTransactionHistories, ConfigureBankTransactionHistories);

            builder.Ignore(e => e.DomainEvents);
        }

        public void ConfigureBankTransactionHistories(OwnedNavigationBuilder<BankAccount, BankTransactionHistory> builder)
        {
            builder.WithOwner(x => x.BankAccount)
                .HasForeignKey(x => x.BankAccountId);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BankAccountId)
                .IsRequired();

            builder.Property(x => x.AmountDebited)
                .IsRequired();

            builder.Property(x => x.AmountCredited)
                .IsRequired();
        }
    }
}