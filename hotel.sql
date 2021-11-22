/*=========================================
			CRIAÇÃO BANCO DDL
===========================================*/

IF DB_ID('Hotel') IS NULL
	CREATE DATABASE Hotel;		
	Go
	
USE Hotel;

/*=========================================
		CRIAÇÃO TABELAS
===========================================*/

IF object_ID('Hotel..Quarto') IS NULL
BEGIN	
	CREATE TABLE Quarto (
		Numero INT NOT NULL PRIMARY KEY,
		Andar INT,
		Descricao nvarchar(255),
		Ocupado BIT DEFAULT 0,
		Ocupacao_Maxima INT,
		UNIQUE(Numero)
	);
	PRINT 'Tabela Quarto criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Quarto já existe na base'
END


IF object_ID('Hotel..Servico') IS NULL
BEGIN
	CREATE TABLE Servico (
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		Tipo nvarchar(100),
		Descricao nvarchar(200),
		Valor DECIMAL(19,2),
		Ativo BIT DEFAULT 1
	);
	PRINT 'Tabela Servico criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Servico já existe na base'
END


IF object_ID('Hotel..Endereco') IS NULL
BEGIN
	CREATE TABLE Endereco (
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		Estado nvarchar(3),
		Cidade nvarchar(100),
		Logradouro nvarchar(100),
		Rua nvarchar(150),
		Numero int
	);
	PRINT 'Tabela Endereco criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Endereco já existe na base'
END


IF object_ID('Hotel..Pessoa') IS NULL
BEGIN
	CREATE TABLE Pessoa (
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		DataCriacao DATETIME,
		CPF varchar(11),
		Nome nvarchar(200),
		Sexo nvarchar(50),
		Telefone nvarchar(25),
		DDD nvarchar(3),
		Email nvarchar(150),
		Senha nvarchar(255),
		EnderecoId INT,
		UNIQUE (CPF, Email)
	);
	PRINT 'Tabela Pessoa criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Pessoa já existe na base'
END


IF object_ID('Hotel..Cliente') IS NULL
BEGIN
	CREATE TABLE Cliente (
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		PessoaId INT
	);
	PRINT 'Tabela Cliente criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Cliente já existe na base'
END


IF object_ID('Hotel..TipoFuncionario') IS NULL
BEGIN
	CREATE TABLE TipoFuncionario (
	    Id INT PRIMARY KEY,
	    Descricao nvarchar(100)
	);
	PRINT 'Tabela TipoFuncionario criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela TipoFuncionario já existe na base'
END
IF object_ID('Hotel..Funcionario') IS NULL
BEGIN
	CREATE TABLE Funcionario (
		Id INT NOT NULL PRIMARY KEY IDENTITY,
		TipoFuncionarioId INT,
		PessoaId INT,
		DataInativacao DATETIME
	);
	PRINT 'Tabela Funcionario criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Funcionario já existe na base'
END


IF object_ID('Hotel..Estadia') IS NULL
BEGIN
	CREATE TABLE Estadia (
		Id INT NOT NULL PRIMARY KEY IDENTITY, 
	    N_Ocupantes INT,
	    DataEntrada DATETIME,
	    DataSaida DATETIME,
	    ClienteId INT,
	    QuartoNumero INT,
	    Ativo BIT DEFAULT 1,
		DataCancelamento DATETIME
	);
	PRINT 'Tabela Estadia criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela Estadia já existe na base'
END


IF object_ID('Hotel..ServicoPrestado') IS NULL
BEGIN
	CREATE TABLE ServicoPrestado (
	    ServicoId INT,
	    EstadiaId INT,
	 	Ativo BIT DEFAULT 1
		);
	PRINT 'Tabela ServicoPrestado criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela ServicoPrestado já existe na base'
END

/*=========================================
			RESTRIÇÕES - DDL
===========================================*/

ALTER TABLE Cliente ADD CONSTRAINT FK_Cliente
	FOREIGN KEY (PessoaId)
	REFERENCES Pessoa (Id)
	ON DELETE CASCADE;

ALTER TABLE Pessoa ADD CONSTRAINT FK_Pessoa_Endereco
	FOREIGN KEY (EnderecoId)
	REFERENCES Endereco (Id)
	ON DELETE SET NULL;

ALTER TABLE Funcionario ADD CONSTRAINT FK_Funcionario_Pessoa
	FOREIGN KEY (PessoaId)
	REFERENCES Pessoa (Id)
	ON DELETE CASCADE;

ALTER TABLE Funcionario ADD CONSTRAINT FK_Funcionario_Tipo
	FOREIGN KEY (TipoFuncionarioId)
	REFERENCES TipoFuncionario (Id);
ALTER TABLE Estadia ADD CONSTRAINT FK_Estadia_Cliente
    FOREIGN KEY (ClienteId)
    REFERENCES Cliente (Id)
    ON DELETE CASCADE;
 
ALTER TABLE Estadia ADD CONSTRAINT FK_Estadia_Quarto
    FOREIGN KEY (QuartoNumero)
    REFERENCES Quarto (Numero)
   ON DELETE CASCADE;

ALTER TABLE ServicoPrestado ADD CONSTRAINT FK_ServicoPrestado_Servico
    FOREIGN KEY (ServicoId)
    REFERENCES Servico (Id)
    ON DELETE CASCADE;
 
ALTER TABLE ServicoPrestado ADD CONSTRAINT FK_ServicoPrestado_Estadia
    FOREIGN KEY (EstadiaId)
    REFERENCES Estadia (Id)

	--ROLL BACK DAS TABELAS E DO DATABASE

	/*ALTER TABLE Cliente DROP CONSTRAINT [FK_Cliente]
	ALTER TABLE Pessoa DROP CONSTRAINT [FK_Pessoa_Endereco]
	ALTER TABLE Funcionario DROP CONSTRAINT [FK_Funcionario_Pessoa]
	ALTER TABLE Funcionario DROP CONSTRAINT [FK_Funcionario_Tipo]
	ALTER TABLE Estadia DROP CONSTRAINT [FK_Estadia_Cliente]
	ALTER TABLE Estadia DROP CONSTRAINT [FK_Estadia_Quarto]
	ALTER TABLE ServicoPrestado DROP CONSTRAINT [FK_ServicoPrestado_Servico]
	ALTER TABLE ServicoPrestado DROP CONSTRAINT [FK_ServicoPrestado_Estadia]
	DROP TABLE Servico
	DROP TABLE Estadia
	DROP TABLE Funcionario
	DROP TABLE ServicoPrestado
	DROP TABLE Pessoa
	DROP TABLE Quarto
	DROP TABLE Cliente
	DROP TABLE Endereco
	DROP TABLE TipoFuncionario
	Go
	USE master

	DROP DATABASE Hotel*/