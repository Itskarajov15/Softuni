CREATE TABLE Persons
(
	PersonID INT IDENTITY,
	FirstName VARCHAR(50),
	Salary DECIMAL(15, 2),
	PassportID INT UNIQUE
);

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber VARCHAR(100)
);

ALTER TABLE Persons
ADD FOREIGN KEY (PassportId) REFERENCES Passports(PassportId)

INSERT INTO Passports (PassportNumber)
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons (FirstName, Salary, PassportId)
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)