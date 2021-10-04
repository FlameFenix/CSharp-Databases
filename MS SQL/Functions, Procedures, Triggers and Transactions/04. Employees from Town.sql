CREATE PROCEDURE usp_GetEmployeesFromTown @TownName NVARCHAR(10)
AS
BEGIN
SELECT e.FirstName, e.LastName FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.[Name] LIKE @TownName
END

EXEC usp_GetEmployeesFromTown Sofia