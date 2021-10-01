SELECT COUNT(e.EmployeeID) AS [Count] FROM Employees AS e
GROUP BY e.ManagerID
HAVING e.ManagerID IS NULL