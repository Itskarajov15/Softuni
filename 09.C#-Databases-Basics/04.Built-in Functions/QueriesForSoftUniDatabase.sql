--Find first and last names of all employees whose first name starts with "SA"
SELECT FirstName, LastName 
	FROM Employees
	WHERE FirstName LIKE 'Sa%';

--Find first and last names of all employees whose last name contains "ei"
SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%';

--Find the first names of all employees in the departments with ID 3 or 10 and whose hire year is between 1995 and 2005 inclusive
SELECT FirstName
	FROM Employees
	WHERE (DepartmentID = 3 OR DepartmentID = 10) 
	AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--Find the first and last names of all employees whose job titles does not contain "engineer"
SELECT FirstName, LastName
	FROM Employees
	WHERE NOT JobTitle LIKE '%engineer%';

--Find town names that are 5 or 6 symbols long and order them alphabetically by town name
SELECT [Name] 
	FROM Towns
	WHERE LEN([Name]) BETWEEN 5 AND 6
	ORDER BY [Name] ASC

--Find all towns that start with letters M, K, B or E. Order them alphabetically by town name
SELECT * 
	FROM Towns
	WHERE LEFT([Name], 1) = 'M'
		  OR LEFT([Name], 1) = 'K'
		  OR LEFT([Name], 1) = 'B'
		  OR LEFT([Name], 1) = 'E'
	ORDER BY [Name] ASC

--Find all towns that does not start with letters R, B or D. Order them alphabetically by name
SELECT * 
	FROM Towns
	WHERE LEFT([Name], 1) NOT LIKE '[RDB]'
	ORDER BY [Name] ASC

--Create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000

--Find the names of all employees whose last name is exactly 5 characters long
SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

--Rank all employees partitioned by Salary and ordered by EmployeeID
SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE (Salary BETWEEN 10000 AND 50000)
	ORDER BY Salary DESC

--Find only employees with rank 2
SELECT * FROM(
	SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE (Salary BETWEEN 10000 AND 50000)
) AS Result
	WHERE [Rank] = 2
	ORDER BY Salary DESC