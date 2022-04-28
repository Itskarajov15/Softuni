/*
Write a stored procedure that selects the full names of all people
*/
CREATE PROC usp_GetHoldersFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name] 
		FROM AccountHolders

/*
Create a stored procedure that accepts a number as a parameter and returns all people who have more money in
total of all their accounts than the supplied number
*/
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@money DECIMAL(15, 2))
AS
	SELECT FirstName, LastName
	FROM AccountHolders ah
	JOIN Accounts a ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @money
	ORDER BY FirstName, LastName

--
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15, 2), @yearlyInterestRate FLOAT, 
@numberOfYears INT)
RETURNS DECIMAL (15, 4)
BEGIN
	RETURN POWER((1 + @yearlyInterestRate), @numberOfYears) * @sum
END

/*
Create a stored procedure to give an interest to a person's account for 5 years
*/
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
	SELECT a.Id AS [Account Id],
		FirstName AS [First Name], 
		LastName AS [Last Name],
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts a
	JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId