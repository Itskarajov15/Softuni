CREATE DATABASE [Service]

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATE,
	Age INT,
	Email VARCHAR(50) NOT NULL,

	CHECK (Age BETWEEN 14 AND 110)
);

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATE,
	Age INT,
	DepartmentId INT,

	CHECK (Age BETWEEN 18 AND 110),
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,

	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
);

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL,
	StatusId INT NOT NULL,
	OpenDate DATE NOT NULL,
	CloseDate DATE,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT NOT NULL,
	EmployeeId INT,

	FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
	FOREIGN KEY (StatusId) REFERENCES [Status](Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

--
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--
DELETE FROM Reports
	WHERE StatusId = 4

--
SELECT [Description],
	   FORMAT(OpenDate, 'dd-MM-yyyy')
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC, 
			 [Description] ASC

--
SELECT [Description],
	   c.[Name] AS CategoryName
	FROM Reports r
	JOIN Categories c ON r.CategoryId = c.Id
	WHERE CategoryId IS NOT NULL
	ORDER BY [Description] ASC, c.[Name] ASC

--
SELECT TOP(5)
	   c.[Name],
	   COUNT(*) AS ReportsNumber
	FROM Categories c
	JOIN Reports r ON c.Id = r.CategoryId
	GROUP BY c.[Name]
	ORDER BY ReportsNumber DESC, c.[Name] ASC

--
SELECT u.Username,
	   c.[Name] AS CategoryName
	FROM Users u
	JOIN Reports r ON u.Id = r.UserId
	JOIN Categories c ON r.CategoryId = c.Id
	WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, OpenDate) AND
		DATEPART(DAY, u.Birthdate) = DATEPART(DAY, OpenDate)
	ORDER BY u.Username ASC, c.[Name] ASC

--
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(r.Id) AS UsersCount
	FROM Employees e
	LEFT JOIN Reports r ON e.Id = r.EmployeeId
	GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
	ORDER BY UsersCount DESC, FullName ASC

--
SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
       ISNULL(d.[Name], 'None') AS Department,
	   c.[Name] AS Category,
	   r.[Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
	FROM Reports r
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	LEFT JOIN [Status] s ON r.StatusId = s.Id
	LEFT JOIN Employees e ON r.EmployeeId = e.Id	
	LEFT JOIN Departments d ON e.DepartmentId = d.Id
	LEFT JOIN Users u ON r.UserId = u.Id
	ORDER BY e.FirstName DESC,
	         e.LastName DESC,
			 d.[Name] ASC,
			 c.[Name] ASC,
			 r.[Description] ASC,
			 r.[OpenDate] ASC,
			 s.[Label] ASC,
			 u.[Name] ASC

--
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

--

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @categoryDepartmentId INT = (SELECT c.DepartmentId 
											FROM Reports r
											JOIN Categories c ON R.CategoryId = C.Id
											WHERE r.Id = @ReportId)

	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId 
											FROM Employees
											WHERE Id = @EmployeeId)

	IF(@categoryDepartmentId = @employeeDepartmentId)
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
	END
	ELSE
	BEGIN
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	END
GO