CREATE PROCEDURE usp_EmployeesBySalaryLevel (@Type NVARCHAR(10))
AS
BEGIN
SELECT FirstName, LastName FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @Type
END

EXEC usp_EmployeesBySalaryLevel 'High'