CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(500) NOT NULL
);

INSERT INTO Directors (DirectorName, Notes)
VALUES
('Asen Karadzhov', 'Notes of Asen'),
('Brenden Craig', 'Notes of Brenden'),
('Zane Chaney', 'Notes of Zane'),
('Tobias Nash', 'Notes of Tobias'),
('Bert Hodges', 'Notes of Bert')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(500) NOT NULL
);

INSERT INTO Genres (GenreName, Notes)
VALUES
('Drama', 'Notes 1'),
('Horror', 'Notes 2'),
('Comedy', 'Notes 3'),
('Genre 1', 'Notes 4'),
('Genre 2', 'Notes 5')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(500) NOT NULL
);

INSERT INTO Categories (CategoryName, Notes)
VALUES
('Category 1', 'Notes 1'),
('Category 2', 'Notes 2'),
('Category 3', 'Notes 3'),
('Category 4', 'Notes 4'),
('Category 5', 'Notes 5')

SELECT * FROM Categories

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(30) NOT NULL,
	DirectorId INT,
	CopyrightYear DATE,
	[Length] TIME,
	GenreId INT,
	CategoryId INT,
	Rating DECIMAL(2, 1),
	Notes VARCHAR(500)
);

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
('First Movie', '1', '1991', '00:05:00', '1','1', NULL, NULL),
('Second Movie', '2', '1992', '00:04:00', '2','5', NULL, NULL),
('Third Movie', '3', '1993', '00:03:00', '5','4', NULL, NULL),
('Forth Movie', '4', '1994', '00:02:00', '4', '3', NULL, NULL),
('Fifth Movie', '5', '1995', '00:01:00', '3','2', NULL, NULL)