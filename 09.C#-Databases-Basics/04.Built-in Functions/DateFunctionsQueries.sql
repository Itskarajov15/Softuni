SELECT ProductName, OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM Orders

CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthdate DATETIME NOT NULL
);

INSERT INTO People ([Name], Birthdate)
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.00')

SELECT [Name], 
	FLOOR(DATEDIFF(DAY, Birthdate, GETDATE()) / 365.25) AS [Age in Years],
	FLOOR(DATEDIFF(DAY, Birthdate, GETDATE()) / 365.25) * 12 AS [Age in Months],
	FLOOR(DATEDIFF(DAY, Birthdate, GETDATE()) / 365.25) * 365 AS [Age in Days]
	FROM People