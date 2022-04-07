CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
);

INSERT INTO Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
(1, 'Category 1', 5, 6, 4, 5),
(2, 'Category 2', 5, 10, 7, 3),
(3, 'Category 3', 7, 6, 1, 9)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear SMALLINT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX) NOT NULL,
	Condition VARCHAR(100) NOT NULL,
	Available BIT NOT NULL
);

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
(1, 'Plate 1', 'Mercedes', 'S Class', 2022, 1, 4, 'Nema snimka brat', 'Perfect', 1),
(2, 'Plate 2', 'Mercedes', 'E Class', 2022, 2, 4, 'Nema snimka bratt', 'Very Good', 1),
(3, 'Plate 3', 'Mercedes', 'C Class', 2022, 3, 4, 'Nema snimka brattt', 'Fantastic', 1)

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
(1, 'First Name 1', 'Last Name 1', 'Director 1', NULL),
(2, 'First Name 2', 'Last Name 2', 'Director 2', NULL),
(3, 'First Name 3', 'Last Name 3', 'Director 3', NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY NOT NULL,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(100) NOT NULL,
	City VARCHAR(30) NOT NULL,
	ZIPCode INT,
	Notes VARCHAR(500)
);

INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
(1, 'Driver Licence Number 1', 'Full Name 1', 'Address 1', 'City 1', 145, NULL),
(2, 'Driver Licence Number 2', 'Full Name 2', 'Address 2', 'City 2', 1234, NULL),
(3, 'Driver Licence Number 3', 'Full Name 3', 'Address 3', 'City 3', 321, NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT,
	KilometrageEnd INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays BIGINT NOT NULL,
	RateApplied INT,
	TaxRate DECIMAL(5, 2) NOT NULL,
	OrderStatus BIT,
	Notes VARCHAR(500)
);

INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 1, 86, 0, 260, '01/01/2002', '01/02/2002', 50, NULL, 5, 1, NULL),
(2, 1, 1, 1, 86, 0, 260, '01/01/2002', '01/02/2002', 50, NULL, 5, 1, NULL),
(3, 1, 1, 1, 86, 0, 260, '01/01/2002', '01/02/2002', 50, NULL, 5, 1, NULL)