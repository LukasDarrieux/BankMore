using BankMore.Transfer.Domain.Interfaces;
using BankMore.Transfer.Domain.TransferenceAggregate;
using BankMore.Transfer.Domain.TransfererenceAggregate.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankMore.Transfer.Infra.Repositories
{
    public class TransferenceRepository : ITransferenceRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TransferenceRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task Execute(Transference transference)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"INSERT INTO Transferencia(IdTransferencia, IdContaCorrenteOrigem, IdContaCorrenteDestino, DataMovimento, Valor) VALUES(@IdTransferencia, @IdContaCorrenteOrigem, @IdContaCorrenteDestino, @Data, @Valor)";

            var parameters = new
            {
                IdTransferencia = new Guid(),
                IdContaCorrenteOrigem = transference.IdAccountOrigin,
                IdContaCorrenteDestino = transference.IdAccountDestiny,
                Valor = transference.Value,
                Data = DateTime.Now
            };

            await connection.ExecuteScalarAsync(sql, parameters);
        }
    }
}
