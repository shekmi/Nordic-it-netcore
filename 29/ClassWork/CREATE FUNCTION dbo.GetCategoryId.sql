--Функции

CREATE FUNCTION dbo.GetCategoryId (
	@categoryName AS VARCHAR(50)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	-- сначала ищем по точному соответствию
	DECLARE @guid AS UNIQUEIDENTIFIER
	SELECT @guid = Id
	FROM dbo.Category
	WHERE [Name] = @categoryName

	-- если не нашли, ищем по начальным символам
	IF(@guid IS NULL)
	BEGIN
		SELECT TOP 1 @guid = Id -- TOP 1 ограничивает выборку guid из таблицы
		FROM dbo.Category
		WHERE [Name] LIKE @categoryName + '%'
	END

	-- если не нашли, возвращаем null
	RETURN (@guid)

END

GO