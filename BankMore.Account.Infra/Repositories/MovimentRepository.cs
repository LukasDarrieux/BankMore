using BankMore.Account.Domain.AccountAggregate;
using BankMore.Account.Domain.Interfaces;
using BankMore.Account.Domain.MovimentAggregate;
using BankMore.Account.Domain.MovimentAggregate.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Account.Infra.Repositories
{
    public class MovimentRepository : IMovimentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MovimentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task Deposit(string numberAccount, decimal value)
        {
            var moviment = new Moviment()
            {
                IdMoviment = new Guid(),
                IdAccount = new Guid(numberAccount),
                Type = EnumTypeMoviment.Credit,
                Value = value
            };

            await InsertData(moviment);
        }

        public async Task Withdraw(string numberAccount, decimal amount)
        {
            var moviment = new Moviment()
            {
                IdMoviment = new Guid(),
                IdAccount = new Guid(numberAccount),
                Type = EnumTypeMoviment.Debit,
                Value = amount
            };

            await InsertData(moviment);
        }

        public async Task<IEnumerable<Moviment>> GetMoviments(string numberAccount)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"SELECT IdMovimento AS IdMoviment, IdContaCorrente AS IdAccount, Tipo AS Type, Valor AS Value 
                        FROM Movimento 
                        WHERE IdContaCorrente IN (SELECT IdContaCorrente FROM ContaCorrente WHERE Numero = @Numero)";

            var moviments = await connection.QueryAsync<Domain.MovimentAggregate.Moviment>(sql, new { Numero = numberAccount });
            return moviments;
        }

        private async Task InsertData(Moviment moviment)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO Movimento(IdMovimento, IdContaCorrente, Tipo, Valor) VALUES(@IdMovimento, @IdContaCorrente, @Tipo, @Valor)";

            var parameters = new
            {
                IdMovimento = moviment.IdMoviment,
                IdContaCorrente = moviment.IdAccount,
                Tipo = moviment.Type.ToString(),
                Valor = moviment.Value
            };

            await connection.ExecuteScalarAsync(sql, parameters);
        }
    }
}
