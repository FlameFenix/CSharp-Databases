CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value MONEY)
AS
BEGIN
	SELECT FirstName AS [First Name]
		 , LastName AS [Last Name] 
    FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @value
	ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 15000