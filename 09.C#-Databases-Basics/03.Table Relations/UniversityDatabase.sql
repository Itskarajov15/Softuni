EXEC sp_changedbowner 'sa'

CREATE DATABASE University

USE University

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
);

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50),
	MajorID INT
);

ALTER TABLE Students
ADD FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount DECIMAL (15, 2),
	StudentID INT
);

ALTER TABLE Payments
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
);

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID, SubjectID)
);