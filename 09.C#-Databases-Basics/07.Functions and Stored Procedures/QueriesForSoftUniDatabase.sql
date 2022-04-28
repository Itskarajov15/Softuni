/*
Create stored procedure that returns all employees’ first and last names for whose salary is above 35000
*/
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName,
	       LastName
		FROM Employees
		WHERE Salary > 35000
GO

/*
Create stored procedure that accept a number (of type DECIMAL(18,4)) as parameter and returns all employees’ 
first and last names whose salary is above or equal to the given number
*/
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@GivenSalary DECIMAL(18, 4))
AS
	SELECT FirstName,
		   LastName
		FROM Employees
		WHERE Salary >= @GivenSalary
GO

/*
Write a stored procedure that accept string as parameter and returns all town names starting with that string
*/
CREATE PROC usp_GetTownsStartingWith (@GivenString VARCHAR(MAX))
AS
	SELECT [Name] 
		FROM Towns
		WHERE [Name] LIKE @GivenString + '%'
GO

/*
Write a stored procedure that accepts town name as parameter and return the employees’ first and last name that 
live in the given town
*/
CREATE PROC usp_GetEmployeesFromTown (@TownName VARCHAR(MAX))
AS
SELECT FirstName,
	   LastName
	FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE [Name] = @TownName
GO

/*
Write a function that receives salary of an employee and returns the level of the salary
*/
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
BEGIN
	DECLARE @result VARCHAR(10)
	IF (@salary < 30000)
		SET @result = 'Low'
	ELSE IF (@salary <= 50000)
		SET @result = 'Average'
	ELSE
		SET @result = 'High'

	RETURN @result
END

/*
Write a stored procedure that receive as parameter level of salary (low, average or high) and print the names of 
all employees that have given level of salary
*/
CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
	SELECT FirstName,
	       LastName
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
GO

/*
Define a function that returns true or false depending on that if the word is a comprised of the given set of 
letters
*/
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @count INT = 1;

	WHILE (@count <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1);

		IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
			RETURN 0

		SET @count += 1;
	END

	RETURN 1
END