CREATE PROCEDURE usp_GetTownsStartingWith @StartingStr NVARCHAR(10)
AS
BEGIN
SELECT t.[Name] FROM Towns AS t
WHERE t.[Name] LIKE @StartingStr + '%'
END

EXEC usp_GetTownsStartingWith b