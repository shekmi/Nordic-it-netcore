CREATE PROCEDURE dbo.CreateGoodsItem (
	@categoryName AS VARCHAR(50),
	@goodsItemName AS NVARCHAR(100),
	@goodsItemId AS INT OUTPUT)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @guid AS UNIQUEIDENTIFIER
	SELECT @guid = dbo.GetCategoryId(@categoryName)
	IF (@guid IS NULL)
		EXECUTE dbo.CreateCategory @categoryName = @categoryName, @guid = @guid OUTPUT
	INSERT INTO dbo.Goods(CategoryId, [Name])
	VALUES (@guid, @goodsItemName)
	SET @goodsItemId = SCOPE_IDENTITY()
END
GO

DECLARE @itemId AS INT
EXEC dbo.CreateGoodsItem @categoryName = 'TV', @goodsItemName = 'Logitech Mouse', @goodsItemId = @itemId OUTPUT
SELECT @itemId

SELECT * FROM dbo.Goods