/*
Select EmployeeId, JobTitle, AddressId and AddressText and return first 5 records sorted by AddressId
*/
SELECT TOP(5)
		e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID 
	ORDER BY e.AddressID ASC

/*
Select FirstName, LastName, Town, AddressText of first 50 records and sort them
*/
SELECT TOP(50)
		e.FirstName, 
		e.LastName,
		t.[Name] AS Town,
		a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	ORDER BY e.FirstName ASC, e.LastName

SELECT * FROM Addresses

/*
Select EmployeeID, FirstName, LastName, DepartmentID only of employees from 'Sales' department.
*/
SELECT e.EmployeeID,
		e.FirstName,
		e.LastName,
		d.[Name] AS DepartmentName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY EmployeeID ASC

/*
Select EmployeeId, FirstName, Salary and DepartmentName of first 5 employees with salary > 15000
*/
SELECT TOP(5)
		e.EmployeeID,
		e.FirstName,
		e.Salary,
		d.[Name] AS DepartmentName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID ASC

/*
Select EmployeeID and FirstName of employees without a project
*/
SELECT TOP(3)
	   e.EmployeeID,
       e.FirstName
	FROM Employees e
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID ASC

/*
Select FirstName, LastName, HireDate, DeptName of employees hired after 1.1.1999 and are from either 
'Sales' or 'Finance'
*/
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01' AND
		d.[Name] IN ('Sales', 'Finance')
	ORDER BY e.HireDate ASC

/*
Select first 5 employees with a project which has started after 13.08.2002 and it is still going
*/
SELECT TOP(5)
		e.EmployeeID,
		e.FirstName,
		p.[Name] AS ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > 2002-08-13 AND p.EndDate IS NULL
	ORDER BY EmployeeID

/*
Filter all projects of employee with id 24, if the project has started during or after 2005 return NULL
*/
SELECT e.EmployeeID,
	   e.FirstName,
	   CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.[Name]
	   END AS ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24

/*
Filter all employees with a manager who has ID equals to 3 or 7. 
Return all the rows, sorted by EmployeeID in ascending order.
*/
SELECT e.EmployeeID,
	   e.FirstName,
	   e.ManagerID,
	   m.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees m ON m.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN (3, 7)
	ORDER BY e.EmployeeID

/*
Show first 50 employees with their managers and the departments they are in (show the departments of the employees).
Order by EmployeeID.
*/
SELECT TOP(50)
	   e.EmployeeID,
	   CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	   CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName
	FROM Employees e
	JOIN Employees m ON m.EmployeeID = e.ManagerID
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID

/*
Write a query that returns the value of the lowest average salary of all departments.
*/
SELECT TOP(1)
		(SELECT AVG(Salary)
			FROM Employees e
			WHERE DepartmentID = d.DepartmentID) AS MinAverageSalary
	FROM Departments d
	ORDER BY MinAverageSalary ASC

/*
Another solution of previous task
*/
SELECT TOP(1)
		AVG(Salary) AS MinAverageSalary 
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY MinAverageSalary ASC