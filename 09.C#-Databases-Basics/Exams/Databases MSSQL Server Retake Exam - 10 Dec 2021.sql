CREATE DATABASE Airport

USE Airport

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age TINYINT NOT NULL,
	Rating FLOAT,

	CHECK (Age BETWEEN 21 AND 62),
	CHECK (Rating BETWEEN 0.0 AND 10.0)
);

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
);

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL,

	FOREIGN KEY (TypeId) REFERENCES AircraftTypes(Id)
);

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL,
	PilotId INT NOT NULL,

	CONSTRAINT PK_AircraftId_PilotId PRIMARY KEY (AircraftId, PilotId),
	FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id),
	FOREIGN KEY (PilotId) REFERENCES Pilots(Id)
);

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) NOT NULL,
	Country VARCHAR(100) NOT NULL
);

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL,
	PassengerId INT NOT NULL,
	TicketPrice DECIMAL(18, 2) DEFAULT 15 NOT NULL,

	FOREIGN KEY (AirportId) REFERENCES Airports(Id),
	FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id),
	FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);

--
INSERT INTO Passengers
SELECT CONCAT(FirstName, ' ', LastName), FirstName + LastName + '@gmail.com' FROM Pilots
WHERE Id BETWEEN 5 AND 15;

--
UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition IN ('C', 'B')) AND 
	  (FlightHours IS NULL OR FlightHours <= 100) AND 
	  ([Year] >= 2013)

--
DELETE FROM Passengers
	WHERE LEN(FullName) <= 10

--
SELECT Manufacturer,
	   Model,
	   FlightHours,
	   Condition
	FROM Aircraft
	ORDER BY FlightHours DESC

--
SELECT FirstName,
	   LastName,
	   Manufacturer,
	   Model,
	   FlightHours
	FROM Pilots p
	JOIN PilotsAircraft pa ON p.Id = pa.PilotId
	JOIN Aircraft a ON pa.AircraftId = a.Id
	WHERE FlightHours IS NOT NULL AND FlightHours <= 304
	ORDER BY FlightHours DESC, FirstName

--
SELECT TOP(20)
	   fd.Id,
	   [Start],
	   FullName,
	   AirportName,
	   TicketPrice
	FROM FlightDestinations fd
	JOIN Passengers p ON fd.PassengerId = p.Id
	JOIN Airports a ON fd.AirportId = a.Id
	WHERE DATEPART(DAY, [Start]) % 2 = 0
	ORDER BY TicketPrice DESC, AirportName

--
SELECT AircraftId,
	   Manufacturer,
	   FlightHours,
	   COUNT(*) AS FlightDestinationsCount,
	   ROUND(AVG(TicketPrice), 2) AS AvgPrice
	FROM Aircraft a
	JOIN FlightDestinations fd ON a.Id = fd.AircraftId
	GROUP BY AircraftId, Manufacturer, FlightHours
	HAVING COUNT(*) >= 2
	ORDER BY FlightDestinationsCount DESC, AircraftId

--
SELECT FullName,
	   COUNT(*) AS CountOfAircraft,
	   SUM(TicketPrice) AS TotalPayed
	FROM Passengers p
	JOIN FlightDestinations fd ON p.Id = fd.PassengerId
	JOIN Aircraft a ON fd.AircraftId = a.Id
	WHERE CHARINDEX('a', FullName) = 2
	GROUP BY FullName
	HAVING COUNT(*) > 1
	ORDER BY FullName

--
SELECT AirportName,
	   [Start] AS DayTime,
	   TicketPrice,
	   FullName,
	   Manufacturer,
	   Model
	FROM FlightDestinations fd
	JOIN Airports a ON fd.AirportId = a.Id
	JOIN Passengers p ON fd.PassengerId = p.Id
	JOIN Aircraft ar ON fd.AircraftId = ar.Id
	WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20 AND
		  TicketPrice > 2500
	ORDER BY Model

--
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
BEGIN
	RETURN (SELECT COUNT(*) 
				FROM Passengers p
				JOIN FlightDestinations fd ON p.Id = fd.PassengerId
				WHERE Email = @email)
END

--
CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
SELECT AirportName,
       FullName,
	   CASE
			WHEN TicketPrice < 400 THEN 'Low'
			WHEN TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			ELSE 'High'
	   END AS LevelOfTickerPrice,
	   Manufacturer,
	   Condition,
	   TypeName
	FROM Airports a
	JOIN FlightDestinations fd ON a.Id = fd.AirportId
	JOIN Passengers p ON fd.PassengerId = p.Id
	JOIN Aircraft ar ON fd.AircraftId = ar.Id
	JOIN AircraftTypes at ON ar.TypeId = at.Id
	WHERE AirportName = @airportName
	ORDER BY Manufacturer, FullName
GO