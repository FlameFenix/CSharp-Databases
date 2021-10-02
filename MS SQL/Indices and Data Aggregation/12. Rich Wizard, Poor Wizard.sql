SELECT * FROM WizzardDeposits

SELECT SUM([Diffrence]) AS SumDiffrence FROM
(
SELECT 
	FirstName AS [Host Wizard],
	DepositAmount AS [Host Wizard Deposit],
	LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
	LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
	DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Diffrence
FROM WizzardDeposits
) AS SubQuerryDiffrence