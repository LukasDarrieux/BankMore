using BankMore.Account.Domain.AccountAggregate;
using BankMore.Account.Domain.AccountAggregate.Repositories;
using BankMore.Account.Domain.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AccountRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<int> CreateAsync(Domain.AccountAggregate.Account account)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO ContaCorrente(IdContaCorrente, Nome, Senha, CPF, Numero, Ativo) OUTPUT INSERTED.Numero VALUES(@IdContaCorrente, @Nome, @Senha, @CPF, @Numero, 1)";

            var parameters = new
            {
                IdContaCorrente = account.Id,
                Nome = account.Name,
                Senha = account.Password,
                CPF = account.CPF,
                Numero = new Random().NextInt64(1000, 9999)
            };

            return await connection.ExecuteScalarAsync<int>(sql, parameters);
        }

        public async Task DeactivateAsync(Guid id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"UPDATE ContaCorrente SET Ativo = 0 WHERE IdContaCorrente = @IdContaCorrente";

            await connection.ExecuteScalarAsync(sql, new { IdContaCorrente = id });
        }

        public async Task<Domain.AccountAggregate.Account?> GetByNumberOrCPFAsync(string numberOrCPF)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"SELECT IdContaCorrente AS Id, Nome AS Name, CPF as CPF, Numero as Number, Ativo AS Active, Senha As Password 
                       FROM ContaCorrente WHERE Numero = @NumberOrCPF OR CPF = @NumberOrCPF";

            var account = await connection.QueryAsync<Domain.AccountAggregate.Account>(sql, new { NumberOrCPF = numberOrCPF });
            
            return account.FirstOrDefault();
        }

        
    }
}
