/*
Create a query that shows the total sum of salaries for each department
*/
SELECT DepartmentID, SUM(Salary) 
	FROM Employees 
	GROUP BY DepartmentID

/*
Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired 
after 01/01/2000
*/
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM Employees
	WHERE DepartmentID IN (2, 5, 7) AND
		  HireDate > '2000-01-01'
	GROUP BY DepartmentID

/*
Select all employees who earn more than 30000 into a new table. Then delete all employees who have ManagerID = 42 
(in the new table). Then increase the salaries of all employees with DepartmentID=1 by 5000. Finally, select the 
average salaries in each department.
*/
SELECT * 
	INTO MyTable
	FROM Employees
	WHERE Salary > 30000

DELETE
	FROM MyTable
	WHERE ManagerID = 42

UPDATE MyTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM MyTable
	GROUP BY DepartmentID

/*
Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 ? 70000
*/
SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

/*
Count the salaries of all employees who don?t have a manager
*/
SELECT COUNT(*) AS Count
	FROM Employees
	WHERE ManagerID IS NULL

/*
Find the third highest salary in each department if there is such
*/
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary  
	FROM (SELECT DepartmentId, Salary,
	   DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
	FROM Employees) AS k
	WHERE [Rank] = 3

/*
Select all employees who have salary higher than the average salary of their respective departments. 
Select only the first 10 rows. Order by DepartmentID.
*/
SELECT TOP(10) FirstName, LastName, DepartmentID 
	FROM Employees e
	WHERE Salary > (SELECT AVG(Salary) 
						FROM Employees
						WHERE e.DepartmentID = DepartmentID)
	ORDER BY DepartmentID