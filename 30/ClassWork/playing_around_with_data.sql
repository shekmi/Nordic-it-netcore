SELECT * FROM dbo.Category
SELECT * FROM dbo.Goods

DECLARE @id AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @categoryName = 'PC Mouse', @guid = @id OUTPUT
SELECT @id
GO

DECLARE @itemId AS INT
EXEC dbo.CreateGoodsItem @categoryName = 'PC Mouse', @goodsItemName = 'Logitech Mouse', @goodsItemId = @itemId OUTPUT
SELECT @itemId
GO

DECLARE @itemId AS INT
EXEC dbo.CreateGoodsItem @categoryName = 'PC Mouse', @goodsItemName = 'Bloody', @goodsItemId = @itemId OUTPUT
SELECT @itemId
GO

DECLARE @itemId AS INT
EXEC dbo.CreateGoodsItem @categoryName = 'Tablet Mouse', @goodsItemName = 'Logitech Mouse', @goodsItemId = @itemId OUTPUT
SELECT @itemId

EXECUTE dbo.CreateCategory 'Other', NULL

SELECT * FROM dbo.Category
SELECT * FROM dbo.Goods


SELECT
	G.Name,
	C.Name
FROM dbo.Goods AS G
INNER JOIN dbo.Category AS C
	ON C.Id = G.CategoryId

SELECT
 G.Name,
 C.Name
FROM dbo.Goods AS G
RIGHT JOIN dbo.Category AS C
	ON C.Id = G.CategoryId