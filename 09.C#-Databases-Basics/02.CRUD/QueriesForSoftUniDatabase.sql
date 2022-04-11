USE SoftUni

--Find all available information about the Departments
SELECT * FROM Departments

--Find all Department names
SELECT [NAME] FROM Departments

--Find the first name, last name and salary of each employee
SELECT [FirstName], [LastName], [Salary] FROM Employees

--Find the first, middle and last name of each employee
SELECT [FirstName], [MiddleName], [LastName] FROM Employees

--Find Full Email Address, figured by first and last name and domain
SELECT [FirstName] + '.' + [LastName] + '@' + 'softuni.bg' AS [Full Email Address] FROM Employees

--Find all different employee’s salaries
SELECT DISTINCT [Salary] FROM Employees

--Find all information about the employees whose job title is “Sales Representative”
SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

--Find the first name, last name and job title of all employees whose salary is in the range [20000, 30000]
SELECT [FirstName], [LastName], [JobTitle] FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000

--Find the full name of all employees whose salary is 25000, 14000, 12500 or 23600
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)

--Find first and last names about those employees that does not have a manager
SELECT [FirstName], [LastName] 
	FROM Employees
	WHERE ManagerID is NULL

--Find first name, last name and salary of those employees who has salary more than 50000 and order them in decreasing order
SELECT [FirstName], [LastName], [Salary]
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

--Find first and last names about 5 best paid Employees ordered descending by their salary
SELECT TOP(5) [FirstName], [LastName]
	FROM Employees
	ORDER BY Salary DESC

--Find the first and last names of all employees whose department ID is different from 4
SELECT [FirstName], [LastName]
	FROM Employees
	WHERE DepartmentID != 4

--Order columns by miltiple criteria
SELECT * FROM Employees
	ORDER BY Salary DESC,
			 FirstName ASC,
			 LastName DESC,
			 MiddleName ASC

--Create view with first name, last name and salary for each employee
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary] 
FROM Employees

--Create view with full name and salary and replace middle name where null with empty string
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle
	FROM Employees

--Find all distinct job titles
SELECT DISTINCT JobTitle FROM Employees

--Find first 10 started projects. Select all information about them and sort them by start date, then by name
SELECT TOP(10) * 
	FROM Projects
	ORDER BY StartDate,
		     [Name] ASC

--Find last 7 hired employees. Select their first, last name and their hire date
SELECT TOP(7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC

--Increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%
UPDATE Employees
	SET Salary *= 1.12
	WHERE DepartmentID IN(1, 2, 4, 11)

SELECT Salary FROM Employees