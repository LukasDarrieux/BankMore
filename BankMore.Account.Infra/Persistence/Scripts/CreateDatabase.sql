IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE NAME = 'bankMoreAccountUser')
BEGIN
	CREATE LOGIN [bankMoreAccountUser] WITH PASSWORD = 'b@nkMoreAccount!@#2026';
	PRINT 'Usuário bankMoreAccountUser criado com sucesso';
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE NAME = 'CONTACORRENTE') 
BEGIN
    CREATE DATABASE [CONTACORRENTE];
    PRINT 'Banco de dados criado com sucesso.';
END;
GO

USE [CONTACORRENTE];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE NAME = 'bankMoreAccountUser')
BEGIN
	CREATE USER [bankMoreAccountUser] FOR LOGIN [bankMoreAccountUser];
	PRINT 'Usuário bankMoreAccountUser adicionado no banco de dados';
	ALTER ROLE db_owner ADD MEMBER [bankMoreAccountUser]
	PRINT 'Usuário bankMoreAccountUser adicionado como dono do banco de dados';
END;
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ContaCorrente')
BEGIN
	CREATE TABLE ContaCorrente (
		IdContaCorrente UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
		Numero VARCHAR(15) NOT NULL ,
		Nome VARCHAR(100) NOT NULL,
		CPF VARCHAR(11) NOT NULL,
		Senha VARCHAR(255) NOT NULL,
		Ativo BIT NULL,
		Saldo DECIMAL(18, 2) NOT NULL DEFAULT(0),
		PRIMARY KEY(IdContaCorrente)
	);
	PRINT 'Tabela de ContaCorrente criada com sucesso';
END;
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Movimento')
BEGIN
	CREATE TABLE Movimento (
		IdMovimento UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
		IdContaCorrente UNIQUEIDENTIFIER NOT NULL,
		Tipo CHAR(1) NOT NULL, -- (C)rédito ou (D)ébito
		Valor DECIMAL(18, 2) NOT NULL,
		PRIMARY KEY(IdMovimento)
	);
	PRINT 'Tabela de Movimento criada com sucesso';
END;
GO
