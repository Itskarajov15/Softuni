CREATE DATABASE ColonialJourney

USE ColonialJourney

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL
	FOREIGN KEY (PlanetId) REFERENCES Planets(Id)
);

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
);

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
);

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL,
	DestinationSpaceportId INT NOT NULL,
	SpaceshipId INT NOT NULL,

	CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	FOREIGN KEY (DestinationSpaceportId) REFERENCES Spaceports(Id),
	FOREIGN KEY (SpaceshipId) REFERENCES Spaceships(Id)
);

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8),
	ColonistId INT NOT NULL,
	JourneyId INT NOT NULL,

	CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	FOREIGN KEY (ColonistId) REFERENCES Colonists(Id),
	FOREIGN KEY (JourneyId) REFERENCES Journeys(Id)
);

--
INSERT INTO Planets ([Name])
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate)
VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6)

--
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--
DELETE FROM TravelCards
	   WHERE JourneyId BETWEEN 1 AND 3

DELETE FROM Journeys
	   WHERE Id BETWEEN 1 AND 3

--
SELECT Id,
	   FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	   FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart ASC

--
SELECT c.Id,
       c.FirstName + ' ' + c.LastName AS [full_name]
	FROM Colonists c
	JOIN TravelCards t ON t.ColonistId = c.Id
	WHERE JobDuringJourney = 'Pilot'
	ORDER BY c.Id ASC

--
SELECT COUNT(*) AS [count]
	FROM Colonists c
	JOIN TravelCards t ON t.ColonistId = c.Id
	JOIN Journeys j ON j.Id = t.JourneyId
	WHERE j.Purpose = 'Technical'

--
SELECT s.[Name],
	   s.Manufacturer
	FROM Spaceships s
	LEFT JOIN Journeys j ON j.SpaceshipId = s.Id
	LEFT JOIN TravelCards t ON t.JourneyId = j.Id
	left JOIN Colonists c ON c.Id = t.ColonistId
	WHERE 1989 < DATEPART(YEAR, c.BirthDate)
	GROUP BY s.[Name], s.Manufacturer
	ORDER BY s.[Name] ASC

--
SELECT p.[Name] AS PlanetName, COUNT(*) AS JourneysCount
	FROM Planets p
	JOIN Spaceports s ON s.PlanetId = p.Id
	JOIN Journeys j ON j.DestinationSpaceportId = s.Id
	GROUP BY p.[Name]
	ORDER BY JourneysCount DESC, p.[Name] ASC

--
SELECT * FROM (SELECT t.JobDuringJourney,
		c.[FirstName] + ' ' + c.LastName AS FullName,
		DENSE_RANK() OVER (PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS [JobRank]
	FROM Colonists c
	JOIN TravelCards t ON t.ColonistId = c.Id) AS Ranked
	WHERE JobRank = 2

--
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @count INT = (SELECT COUNT(*) 
			FROM Colonists c
			JOIN TravelCards tc ON c.Id = tc.ColonistId
			JOIN Journeys j ON tc.JourneyId = j.Id
			JOIN Spaceports s ON j.DestinationSpaceportId = s.Id
			JOIN Planets p ON s.PlanetId = p.Id
			WHERE p.[Name] = @PlanetName)
			
	RETURN @count;
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')