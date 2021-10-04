CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4) 
AS 
BEGIN
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @Number
END

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100