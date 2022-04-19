/*
Find the top 50 games ordered by start date, then by name of the game. Display only games from 2011 and 2012 year. 
Display start date in the format "yyyy-MM-dd"
*/
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] 
	FROM Games
	WHERE DATEPART(YEAR, START) BETWEEN 2011 AND 2012
	ORDER BY Start,
			[Name]
/*
Find all users along with information about their email providers. Display the username and email provider. 
Sort the results by email provider alphabetically, then by username.
*/
SELECT * FROM(
	SELECT [Username], SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email) + 1) 
	AS [Email Provider]
	FROM Users
) AS Result
	ORDER BY [Email Provider],
			 [Username]
/*
Find all users along with their IP addresses sorted by username alphabetically. 
Display only rows that IP address matches the pattern: "***.1^.^.***".
Legend: * - one symbol, ^ - one or more symbols
*/
SELECT Username, IpAddress AS [IP Address]
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

SELECT * FROM(
	SELECT [Name] AS Game,
	CASE
	WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning' 
	WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END
	AS [Part of the Day],
	CASE
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
	END
	AS Duration
	FROM Games
) AS Result
	ORDER BY Game,
			 Duration