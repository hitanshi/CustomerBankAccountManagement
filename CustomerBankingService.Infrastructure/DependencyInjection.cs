using CustomerBankingService.Application.Common.Interfaces;
using CustomerBankingService.Domain.Common.Interfaces;
using CustomerBankingService.Domain.Repositories;
using CustomerBankingService.Infrastructure.Persistence;
using CustomerBankingService.Infrastructure.Repositories;
using CustomerBankingService.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace CustomerBankingService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("8.0"));
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IBankAccountRepository, BankAccountRepository>();
            services.AddTransient<IBankAccountTypeRepository, BankAccountTypeRepository>();
            services.AddTransient<IBankCustomerRepository, BankCustomerRepository>();
            services.AddTransient<ITransferFundRepository, TransferFundRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            return services;
        }
    }
}