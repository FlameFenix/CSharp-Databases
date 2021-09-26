SELECT * FROM EmployeesProjects

SELECT * FROM Projects

SELECT * FROM Employees

SELECT TOP (5) e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID