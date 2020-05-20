--�������

CREATE FUNCTION dbo.GetCategoryId (
	@categoryName AS VARCHAR(50)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	-- ������� ���� �� ������� ������������
	DECLARE @guid AS UNIQUEIDENTIFIER
	SELECT @guid = Id
	FROM dbo.Category
	WHERE [Name] = @categoryName

	-- ���� �� �����, ���� �� ��������� ��������
	IF(@guid IS NULL)
	BEGIN
		SELECT TOP 1 @guid = Id -- TOP 1 ������������ ������� guid �� �������
		FROM dbo.Category
		WHERE [Name] LIKE @categoryName + '%'
	END

	-- ���� �� �����, ���������� null
	RETURN (@guid)

END

GO