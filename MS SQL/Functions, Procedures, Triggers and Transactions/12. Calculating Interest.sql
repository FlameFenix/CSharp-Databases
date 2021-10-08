SELECT ah.Id,
ah.FirstName,
ah.LastName,
a.Balance AS CurrentBalance,
dbo.ufn_CalculateFutureValue(a.Balance , ah.Id / 10.0 ,5 ) AS [Balance in 5 years] 
FROM AccountHolders AS ah
JOIN Accounts AS a
ON ah.Id = a.AccountHolderId