CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
);

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2),

	FOREIGN KEY (CityId) REFERENCES Cities(Id) 
);

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL,

	FOREIGN KEY (HotelId) REFERENCES Hotels(Id)
);

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,

	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate),
	FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE,

	FOREIGN KEY (CityId) REFERENCES Cities(Id)
);

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT NOT NULL,

	CHECK (Luggage >= 0),
	CONSTRAINT PK_AccountId_TripId PRIMARY KEY (AccountId, TripId),
	FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
	FOREIGN KEY (TripId) REFERENCES Trips(Id)
);

--
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--
UPDATE Rooms
SET Price = (Price / 100) * 14 + Price
WHERE HotelId IN (5, 7, 9)

--
DELETE 
	FROM AccountsTrips
	WHERE AccountId = 47

--
SELECT a.FirstName,
	   a.LastName,
	   FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.[Name] AS Hometown,
	   a.Email
	FROM Accounts a
	JOIN Cities c ON c.Id = a.CityId
	WHERE a.Email LIKE 'e%'
	ORDER BY c.[Name] ASC

--
SELECT c.[Name], COUNT(*) AS Hotels
	FROM Cities c
	JOIN Hotels h ON h.CityId = c.Id
	GROUP BY c.[Name]
	ORDER BY Hotels DESC, c.[Name]

--
SELECT a.Id AS AccountId, 
	   (a.FirstName + ' ' + a.LastName) AS FullName,
	   MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
	FROM Accounts a
	JOIN AccountsTrips at ON at.AccountId = a.	Id
	JOIN Trips t ON t.Id = at.TripId
	WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
	GROUP BY a.Id, (a.FirstName + ' ' + a.LastName)
	ORDER BY LongestTrip DESC, ShortestTrip ASC

--
SELECT TOP(10)
	   c.Id,
       c.[Name] AS City,
	   c.CountryCode AS Country, 
	   COUNT(*) AS Accounts
	FROM Cities c
	JOIN Accounts a ON a.CityId = c.Id
	GROUP BY c.Id, c.[Name], c.CountryCode
	ORDER BY Accounts DESC

--
SELECT a.Id, a.Email, c.[Name], COUNT(*) AS Trips 
	FROM Accounts a
	JOIN Cities c ON c.Id = a.CityId
	JOIN AccountsTrips at ON at.AccountId = a.Id
	JOIN Trips t ON t.Id = at.TripId
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON h.Id = r.HotelId
	WHERE h.CityId = c.Id
	GROUP BY a.Id, a.Email, c.[Name]
	ORDER BY Trips DESC, a.Id ASC

--
SELECT TripId AS Id,
       FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
	   ac.Name AS [From],
	   hc.Name AS [To],
	   CASE
			WHEN CancelDate IS NULL THEN CONVERT(NVARCHAR, DATEDIFF(DAY, ArrivalDate, ReturnDate)) + ' days'
			ELSE 'Canceled'END 
		AS Duration
	FROM AccountsTrips at
	JOIN Accounts a ON at.AccountId = a.Id
	JOIN Cities ac ON a.CityId = ac.Id
	JOIN Trips t ON at.TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities hc ON h.CityId = hc.Id
	ORDER BY [Full Name], TripId