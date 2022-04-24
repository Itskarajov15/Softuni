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
SELECT COUNT(*) 
	FROM Journeys
	WHERE Purpose = 'Technical'

SELECT * FROM Colonists