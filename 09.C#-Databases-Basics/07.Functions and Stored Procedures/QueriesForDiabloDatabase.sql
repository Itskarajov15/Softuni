CREATE FUNCTION ufn_CashInUsersGame (@gameName VARCHAR(100))
RETURNS TABLE
AS
	  RETURN (SELECT SUM(k.Cash) AS TotalCash
	FROM (SELECT CASH,
				ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
		FROM Games g	
		JOIN UsersGames ug ON ug.GameId = g.Id
		WHERE [Name] = @gameName) k
 WHERE k.RowNumber % 2 = 1)