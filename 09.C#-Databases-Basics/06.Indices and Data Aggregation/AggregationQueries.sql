--
SELECT d.[Name] AS DepartmentName,
	   COUNT(*) AS [Count],
	   SUM(Salary) AS Salary
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.[Name]
ORDER BY Salary DESC

--
SELECT d.[Name], SUM(Salary) AS Salary
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	GROUP BY d.[Name]
	HAVING SUM(Salary) >= 15000
	ORDER BY Salary DESC