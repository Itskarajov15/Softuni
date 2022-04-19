/*
Show all employees that are hired after 1/1/1999 and are either in Sales ot Finance department
*/
SELECT e.FirstName AS [First Name],
	   e.LastName AS [Last Name],
	   e.HireDate AS [Hire Date],
	   d.[Name] AS [Dept Name]
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01'
		AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
	ORDER BY e.HireDate ASC