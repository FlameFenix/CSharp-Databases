CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @Result NVARCHAR(10)
	IF(@salary < 30000)
		BEGIN
			SET @Result = 'Low'
		END
	ELSE IF(@salary <= 50000)
		BEGIN
			SET @Result = 'Average'
		END
	ELSE
		BEGIN
			SET @Result = 'High'
		END
		RETURN @Result
END

SELECT dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees