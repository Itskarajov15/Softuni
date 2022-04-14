----Create two tables and many-to-many relationship between them
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL
);

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
);

ALTER TABLE Models
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

INSERT INTO Manufacturers (ManufacturerID, [Name], EstablishedOn)
VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

INSERT INTO Models ([Name], ManufacturerID)
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 3),
('Nova', 3)
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30)
);

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50)
);

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT

	CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

INSERT INTO Students ([Name])
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)