IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE NAME = 'bankMoreTransferUser')
BEGIN
	CREATE LOGIN [bankMoreTransferUser] WITH PASSWORD = 'b@nkMoreTransfer!@#2026';
	PRINT 'Usuário bankMoreTransferUser criado com sucesso';
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE NAME = 'TRANSFERENCIA') 
BEGIN
    CREATE DATABASE [TRANSFERENCIA];
    PRINT 'Banco de dados criado com sucesso.';
END;
GO

USE [TRANSFERENCIA];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE NAME = 'bankMoreTransferUser')
BEGIN
	CREATE USER [bankMoreTransferUser] FOR LOGIN [bankMoreTransferUser];
	PRINT 'Usuário bankMoreTransferUser adicionado no banco de dados';
	ALTER ROLE db_owner ADD MEMBER [bankMoreTransferUser]
	PRINT 'Usuário bankMoreTransferUser adicionado como dono do banco de dados';
END;
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transferencia')
BEGIN
	CREATE TABLE Transferencia (
		IdTransferencia UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
		IdContaCorrenteOrigem UNIQUEIDENTIFIER NOT NULL,
		IdContaCorrenteDestino UNIQUEIDENTIFIER NOT NULL,
		DataMovimento DATETIME NOT NULL,
		Valor DECIMAL(18, 2) NOT NULL,
		PRIMARY KEY(IdTransferencia)
	);
	PRINT 'Tabela de Transferencia criada com sucesso';
END;
GO


