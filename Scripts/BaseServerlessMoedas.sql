CREATE DATABASE BaseServerlessMoedas
GO

USE BaseServerlessMoedas
GO

CREATE TABLE dbo.Cotacoes(
	Sigla char(3) NOT NULL,
	NomeMoeda varchar(30) NOT NULL,
	UltimaCotacao datetime NOT NULL,
	Valor NUMERIC (18,4) NOT NULL,
	CONSTRAINT PK_Cotacoes PRIMARY KEY (Sigla)
)
GO


INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,Valor)
     VALUES
           ('USD'
           ,'Dólar norte-americano'
           ,'10/23/2019'
           ,0)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,Valor)
     VALUES
           ('EUR'
           ,'Euro'
           ,'10/23/2019'
           ,0)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,NomeMoeda
           ,UltimaCotacao
           ,Valor)
     VALUES
           ('LIB'
           ,'Libra esterlina'
           ,'10/23/2019'
           ,0)
