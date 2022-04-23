/*
Get total count of records from the table
*/
SELECT COUNT(*) AS [Count]
	FROM WizzardDeposits

/*
Select the size of the longest magic wand. Rename the new column appropriately
*/
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

/*
In each deposit group show the longest magic want
*/
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

/*
Select the two deposit groups with the lowest average wand size
*/
SELECT TOP(2)
		DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize) ASC

/*
Select all deposit groups and their total deposit sums
*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

/*
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands 
crafted by Ollivander family
*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

/*
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted 
by Ollivander family. Filter total deposit amounts lower than 150000. Order by total deposit amount in descending order.
*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

/*
Select DepositGroup, MagicWandCreator and minimum deposit charge for each group in ascending ordered my MagicWandCreator
and DepositGroup
*/
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

/*
Write down a query that creates 7 different groups based on their age
*/
SELECT Result.AgeGroup, COUNT(Result.AgeGroup)	
	FROM (
SELECT CASE
		   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		   WHEN Age >= 61 THEN '[61+]'
	   END AS AgeGroup
   FROM WizzardDeposits) AS Result
GROUP BY Result.AgeGroup

/*
Write a query that returns all unique wizard first letters of their first names only if they have deposit of type 
Troll Chest
*/
SELECT LEFT(FirstName, 1) AS FirstLetter 
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1)

/*
Get average interest of all deposit groups split by whether the deposit has expired or not. Select deposits with 
start date after 01/01/1985
*/
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC,
			 IsDepositExpired ASC

/*
Compare the deposits of every wizard with the wizard after him and sum the difference between the deposits
*/
SELECT SUM(Guest.DepositAmount - Host.DepositAmount) AS [SumDifference]
	FROM WizzardDeposits Host
	JOIN WizzardDeposits Guest ON Host.Id = Guest.Id + 1

/*
Another soluiton of the previous task
*/
SELECT SUM(k.[Diff]) AS SumDifference
	FROM (SELECT Host.DepositAmount - LEAD(Host.DepositAmount, 1) OVER (ORDER BY Host.ID) AS [Diff]
	FROM WizzardDeposits Host) AS k