SELECT * INTO EmployeesAVGSalary FROM Employees AS e
WHERE e.Salary > 30000

DELETE FROM EmployeesAVGSalary
WHERE ManagerID = 42

UPDATE EmployeesAVGSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT eAvg.DepartmentID, AVG(eAvg.Salary) FROM EmployeesAVGSalary AS eAvg
GROUP BY eAvg.DepartmentID



