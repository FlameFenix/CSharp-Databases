SELECT DISTINCT SubQuerry.DepartmentID, Salary FROM
(
SELECT
e.DepartmentID,
DENSE_RANK() OVER(PARTITION BY e.DepartmentId ORDER BY Salary DESC) AS SalaryRank,
e.Salary
FROM Employees AS e
) AS SubQuerry
WHERE SalaryRank = 3