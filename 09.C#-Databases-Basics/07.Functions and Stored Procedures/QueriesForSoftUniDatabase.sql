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