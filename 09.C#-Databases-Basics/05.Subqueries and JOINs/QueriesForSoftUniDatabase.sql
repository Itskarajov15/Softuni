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