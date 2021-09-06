SELECT * FROM Departments   -- TASK 2

SELECT [NAME] FROM Departments -- TAKS 3

SELECT FirstName, LastName, Salary FROM Employees -- TASK 4

SELECT FirstName, MiddleName, LastName FROM Employees -- TASK 5

-- TASK 6

SELECT DISTINCT Salary FROM Employees -- TASK 7

SELECT * FROM Employees
	WHERE JobTitle='Sales Representative' -- TASK 8

SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000 -- TASK 9

SELECT FirstName + ' ' + MiddleName  + ' ' + LastName AS FullName FROM Employees
	WHERE Salary = 25000 OR Salary = 14000  OR Salary = 12500 OR Salary = 23600 -- TASK 10

SELECT FirstName, LastName FROM Employees
	WHERE ManagerID IS NULL -- TASK 11

SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary > 50000 ORDER BY Salary DESC -- TASK 12

SELECT TOP 5 FirstName, LastName FROM Employees
	ORDER BY Salary DESC -- TASK 13

SELECT FirstName, LastName FROM Employees
	WHERE DepartmentID != 4 -- TASK 14

SELECT * FROM Employees
	ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC -- TASK 15