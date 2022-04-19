/*
Display addresses information of first 50 employees in SoftUni database and order them by first name, then by last name
*/
SELECT TOP(50) 
		e.FirstName AS [First Name],
		e.LastName AS [Last Name],
		t.[Name] AS Town,
		a.AddressText AS [Address Text]
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	ORDER BY FirstName, LastName