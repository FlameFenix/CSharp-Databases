CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(10,4), @rate FLOAT, @years INT)
RETURNS DECIMAL(10,4)
BEGIN 
RETURN @sum * (POWER((1 + @rate), @years)) 
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1 ,5 )
