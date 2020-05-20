DROP PROCEDURE IF EXISTS dbo.CreateCategory
GO
CREATE PROCEDURE dbo.CreateCategory (
	@categoryName AS VARCHAR(50),
	@guid AS UNIQUEIDENTIFIER OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tempguid AS UNIQUEIDENTIFIER
	SET @tempguid = NEWID()

	INSERT INTO dbo.Category(Id, [Name])
	VALUES (@tempguid, @categoryName)

	SET @guid = @tempGuid
END
GO

--вызов процедуры
DECLARE @id AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @categoryName = 'TEST', @guid = @id OUTPUT
--SELECT @id
GO 
--вызов процедуры
DECLARE @id AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @categoryName = 'New TEST', @guid = @id OUTPUT
--SELECT @id


--очищаем таблицу
TRUNCATE TABLE dbo.Category	
--очищаем таблицу
TRUNCATE TABLE dbo.Goods

--удаляем FOREIGN KEY
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_CategoryId

SELECT * FROM dbo.Category