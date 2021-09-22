SELECT * FROM Employees

SELECT EmployeeID, FirstName , LastName, Salary,
DENSE_RANK() OVER(PARTITION BY Salary
				  ORDER BY EmployeeID ASC) AS Rank
				  FROM Employees
				  WHERE Salary >= 10000 AND Salary <= 50000
				  

	