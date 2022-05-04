CREATE DATABASE CigarShop

USE CigarShop

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
	RingRange DECIMAL(15, 2) NOT NULL,

	CHECK ([Length] BETWEEN 10 AND 25),
	CHECK(RingRange BETWEEN 1.5 AND 7.5)
);

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
);

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
);

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL,
	TastId INT NOT NULL,
	SizeId INT NOT NULL,
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL,	

	FOREIGN KEY (BrandId) REFERENCES Brands(Id),
	FOREIGN KEY (TastId) REFERENCES Tastes(Id),
	FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
);

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
);

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
	AddressId INT NOT NULL,

	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL,
	CigarId INT NOT NULL,

	CONSTRAINT PK_ClientId_CigarId PRIMARY KEY(CLientId, CigarId),
	FOREIGN KEY (ClientId) REFERENCES Clients(Id),
	FOREIGN KEY (CigarId) REFERENCES Cigars(Id)
);

--
INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

--
UPDATE Cigars
SET PriceForSingleCigar += (PriceForSingleCigar / 100) * 20
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--
DELETE FROM Clients
	WHERE AddressId IN (7, 8, 10)

DELETE FROM Addresses
	WHERE Country LIKE 'C%' 

--
SELECT CigarName,
	   PriceForSingleCigar,
	   ImageURL
	FROM Cigars
	ORDER BY PriceForSingleCigar, CigarName DESC

--
SELECT c.Id,
	   CigarName,
	   PriceForSingleCigar,
	   TasteType,
	   TasteStrength
	FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	WHERE TasteType IN ('Earthy', 'Woody')
	ORDER BY PriceForSingleCigar DESC

--
SELECT Id,
	   CONCAT(FirstName, ' ', LastName) AS ClientName,
	   Email
	FROM Clients c
	LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
	WHERE CigarId IS NULL
	ORDER BY ClientName

--
SELECT TOP(5)
		CigarName,
		PriceForSingleCigar,
		ImageURL
	FROM Cigars c
	JOIN Sizes s ON c.SizeId = s.Id
	WHERE s.[Length] >= 12 AND (CHARINDEX('ci', CigarName) > 0 OR 
	(PriceForSingleCigar > 50 AND RingRange > 2.55))
	ORDER BY CigarName ASC, PriceForSingleCigar DESC

--
SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
	   a.Country,
	   a.ZIP,
	   CONCAT('$', MAX(PriceForSingleCigar)) AS CigarPrice
	FROM Clients c
	JOIN Addresses a ON c.AddressId = a.Id
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cg ON cc.CigarId = cg.Id
	WHERE ISNUMERIC(ZIP) = 1
	GROUP BY CONCAT(FirstName, ' ', LastName), a.Country, a.ZIP

--
SELECT LastName,
	   AVG([Length]) AS CigarLength,
	   CEILING(AVG(RingRange)) AS CigarRingRange
	FROM Clients c
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cg ON cc.CigarId =  cg.Id
	JOIN Sizes s ON cg.SizeId = s.Id
	GROUP BY LastName
	ORDER BY CigarLength DESC

--
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
RETURNS INT
BEGIN
	RETURN (SELECT COUNT(*)
				FROM Clients c
				JOIN ClientsCigars cc ON c.Id = cc.ClientId
				JOIN Cigars cg ON cc.CigarId =  cg.Id
				WHERE FirstName = @name)
END

--
CREATE PROC usp_SearchByTaste(@taste VARCHAR(50)) 
AS
SELECT CigarName,
	   CONCAT('$', PriceForSingleCigar) AS Price,
	   TasteType,
	   BrandName,
	   CONCAT([Length], ' cm') AS CigarLength,
	   CONCAT(RingRange, ' cm') AS CigarRingRange
	FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	JOIN Brands b ON c.BrandId = b.Id
	JOIN Sizes s ON c.SizeId = s.Id
	WHERE TasteType = @taste
	ORDER BY [Length], RingRange DESC
GO