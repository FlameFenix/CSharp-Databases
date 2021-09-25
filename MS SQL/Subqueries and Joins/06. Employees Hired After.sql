SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales' OR d.Name = 'Finance'
ORDER BY e.HireDate