/*
Find all employees that are in the Sales department in SoftUni database
*/
SELECT e.EmployeeID,
		e.FirstName AS [First Name],
		e.LastName AS [Last Name],
		d.[Name] AS [Department Name]
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY EmployeeID