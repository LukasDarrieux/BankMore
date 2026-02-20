using BankMore.Transfer.Domain.Interfaces;
using BankMore.Transfer.Infra.Persistence;
using BankMore.Transfer.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BankMore.Transfer.Domain.TransfererenceAggregate.Repository;

namespace BankMore.Transfer.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<ITransferenceRepository, TransferenceRepository>();

            return services;
        }
    }
}
