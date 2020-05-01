--CREATE DATABASE LiveDemo
--GO
USE LiveDemo
GO
-- BUILD SCHEMA
ALTER TABLE dbo.Goods
	DROP CONSTRAINT IF EXISTS FK_Goods_CategoryId
GO
DROP TABLE IF EXISTS dbo.Category 
GO
CREATE TABLE dbo.Category (
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Category_Name UNIQUE ([Name]))
GO
DROP TABLE IF EXISTS dbo.Goods 
GO
CREATE TABLE dbo.Goods (
	Id INT NOT NULL IDENTITY(1, 1),
	CategoryId UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name]))
GO
ALTER TABLE dbo.Goods
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES dbo.Category(Id)
GO

-- BUILD STORED OBJECTS
DROP FUNCTION IF EXISTS dbo.GetCategoryId
GO
CREATE FUNCTION dbo.GetCategoryId (
	@categoryName AS VARCHAR(50)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @guid AS UNIQUEIDENTIFIER

	-- сначала ищем по точному соответствию
	SELECT @guid = Id
	FROM dbo.Category
	WHERE [Name] = @categoryName

	-- если не нашли, ищем по начальным символам
	IF (@guid IS NULL)
	BEGIN
		SELECT TOP 1 @guid = Id
		FROM dbo.Category
		WHERE [Name] LIKE @categoryName + '%'
	END

	-- если не нашли, возвращаем null
	RETURN (@guid)
END
GO
--
DROP PROCEDURE IF EXISTS dbo.CreateCategory
GO
CREATE PROCEDURE dbo.CreateCategory(
	@categoryName AS VARCHAR(50),
	@guid AS UNIQUEIDENTIFIER OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SET @tempGuid = NEWID()

	INSERT INTO dbo.Category (Id, [Name])
	VALUES (@tempGuid, @categoryName)

	SET @guid = @tempGuid
END
GO
--
DROP PROCEDURE IF EXISTS dbo.CreateGoodsItem
GO
CREATE PROCEDURE dbo.CreateGoodsItem (
	@categoryName AS VARCHAR(50),
	@goodsItemName AS NVARCHAR(100),
	@goodsItemId AS INT OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER

	--Включаем автооткат транзакции, если внутри ошибка
	SET XACT_ABORT ON 

	--Search
	SELECT @guid = dbo.GetCategoryId(@categoryName)

	BEGIN TRAN
	-- Add Category
	IF (@guid IS NULL)
		EXECUTE dbo.CreateCategory @categoryName = @categoryName, @guid = @guid OUTPUT
		-- Не хотели бы здесь находиться фиксируя промежуточные результаты
	INSERT INTO dbo.Goods(CategoryId, [Name])
	VALUES (@guid, @goodsItemName)
	COMMIT

	SET @goodsItemId = SCOPE_IDENTITY()
END
GO