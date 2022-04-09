--Select all records from the Towns, then from Departments and finally from Employees table.
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Modify and Sort

SELECT * FROM Towns
		ORDER BY [Name] ASC

SELECT * FROM Departments
		ORDER BY [Name] ASC

SELECT * FROM Employees
		ORDER BY Salary DESC

--Modify queries from previous problem to show only some of the columns.

SELECT [Name] FROM Towns
		ORDER BY [Name] ASC

SELECT [Name] FROM Departments
		ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
		ORDER BY Salary DESC

--Increase the salary of all employees by 10%.

UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees


--Decrease tax rate by 3%

USE Hotel

UPDATE Payments
SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

--Delete all records from the Occupancies table

DELETE FROM Occupancies