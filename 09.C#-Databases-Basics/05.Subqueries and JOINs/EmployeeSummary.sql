/*
Display information about first 50's employee's manager and employee's department and sort them by employee id
*/
SELECT TOP(50)
		e.EmployeeID,
		e.FirstName + ' ' + e.LastName AS [Employee Name],
		m.FirstName + ' ' + m.LastName AS [Manager Name],
		d.[Name] AS [Department Name]
	FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID