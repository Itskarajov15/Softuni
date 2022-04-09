CREATE DATABASE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(500)
);

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES 
(1, 'Asen', 'Karadzhov', 'Senior', NULL),
(2, 'First Name 1', 'Last name 1', 'Senior', NULL),
(3, 'First name 2', 'Last name 2', 'Senior', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	PhoneNumber VARCHAR(10),
	EmergencyName VARCHAR(30) NOT NULL,
	EmergencyNumber VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES 
(1, 'Asen', 'Karadzhov', '123123', 'Emergency name 1', '1231231', NULL),
(2, 'Asen2', 'Karadzhov2', '123123123', 'Emergency name 2', '1231231', NULL),
(3, 'Asen3', 'Karadzhov3', '123123123', 'Emergency name 3', '1231231', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES 
('Cleaning', NULL),
('Cleaning 2', NULL),
('Cleaning 3', NULL)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO RoomTypes (RoomType, Notes)
VALUES 
('Type 1', NULL),
('Type 2', NULL),
('Type 3', NULL)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO BedTypes (BedType, Notes)
VALUES 
('Type 1', NULL),
('Type 2', NULL),
('Type 3', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES 
(1, 'Type 1', 'Bed type 1', 10, 'Status 1', NULL),
(2, 'Type 2', 'Bed type 2', 7, 'Status 2', NULL),
(3, 'Type 3', 'Bed type 3', 6, 'Status 3', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES 
(1, 1, '01/01/2002', 1, '01/01/2002', '01/01/2008', 100, 213.12123, 10, 9, 500.231, NULL),
(2, 2, '01/01/2002', 2, '01/01/2002', '01/01/2008', 100, 213.12123, 10, 9, 500.231, NULL),
(3, 3, '01/01/2002', 3, '01/01/2002', '01/01/2008', 100, 213.12123, 10, 9, 500.231, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	TotalDays INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge DECIMAL(15, 2) NOT NULL,
	Notes VARCHAR(MAX)
);

INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, TotalDays, 
RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES 
(1, 1, '01/01/2002', 1231231, 100, 1, 10, 123.123, NULL),
(2, 2, '01/01/2002', 1231231, 100, 1, 10, 123.123, NULL),
(3, 3, '01/01/2002', 1231231, 100, 1, 10, 123.123, NULL)