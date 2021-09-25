SELECT 
	ProductName,
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS PayDue,
	DATEADD(MONTH, 1, OrderDate) AS DeliverDue
FROM Orders