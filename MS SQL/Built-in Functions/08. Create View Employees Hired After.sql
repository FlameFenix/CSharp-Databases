CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT FirstName, LastName
FROM Employees
WHERE HireDate >= '1/1/2001'