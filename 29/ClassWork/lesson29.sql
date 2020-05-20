DROP DATABASE IF EXISTS LiveDemo29
GO

CREATE DATABASE LiveDemo29
USE LiveDemo29

CREATE TABLE dbo.Category (
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(50),
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Category_Name UNIQUE ([Name]))
GO

INSERT INTO dbo.Category (Id, [Name]) VALUES(NEWID(), 'Mobile Phones')
INSERT INTO dbo.Category (Id, [Name]) VALUES(NEWID(), 'TV')

SELECT Id, [Name] FROM dbo.Category

SELECT Id, [Name] 
FROM dbo.Category
--WHERE [Name] = 'Mobile Phones'
--���
WHERE [Name] LIKE 'Mobile%' --�� ��� ������ ��� ��� ����������


--BEGIN TRAN


DELETE FROM dbo.Category
WHERE [Name] LIKE 'Mobile%'

--TRUNCATE TABLE dbo.[Category] --������� ��


CREATE TABLE dbo.Goods (
	Id INT NOT NULL IDENTITY(1, 1), --���� ����������� �������������
	CategoryId UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name]))

SELECT * 
FROM dbo.Goods

ALTER TABLE dbo.Goods
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES dbo.Category(Id)

DECLARE @guid AS UNIQUEIDENTIFIER
--SET @guid = '3C60271B-2DF8-455B-85C9-634C31D44C86'

SELECT @guid = Id 
FROM dbo.Category
WHERE [Name] = 'Mobile Phones'

--PRINT @guid

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (@guid, 'iPhone X')

SELECT * FROM dbo.Goods

PRINT 'ID of iPhone X is ' + CONVERT(VARCHAR(15), SCOPE_IDENTITY())
SELECT SCOPE_IDENTITY()

--������� FOREIGN KEY
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_CategoryId

--������� FOREIGN KEY
ALTER TABLE dbo.Goods
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES dbo.Category(Id)

--������� �������
TRUNCATE TABLE dbo.Category	
--������� �������
TRUNCATE TABLE dbo.Goods

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (dbo.GetCategoryId('Mobile Phones'), 'xiami bla-bla-bla')

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (dbo.GetCategoryId('T'), 'Panasonic 12-12 4k')

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (dbo.GetCategoryId('T'), 'SONY 4K')


SELECT * 
FROM dbo.Category

SELECT * FROM dbo.Goods