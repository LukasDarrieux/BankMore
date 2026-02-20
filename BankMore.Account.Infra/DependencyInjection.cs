using BankMore.Account.Domain.AccountAggregate.Repositories;
using BankMore.Account.Domain.Interfaces;
using BankMore.Account.Infra.Persistence;
using BankMore.Account.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankMore.Account.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
