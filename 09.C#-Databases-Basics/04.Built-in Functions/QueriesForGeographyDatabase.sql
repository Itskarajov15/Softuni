--Find all countries that holds the letter 'A' in their name at least 3 times, sorted by ISO code
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] 
	FROM Countries
	WHERE (LEN(CountryName)-LEN(REPLACE(CountryName, 'A', '')))/LEN('A') >= 3
	ORDER BY IsoCode ASC

--Another soluiton of first task
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] 
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode ASC

/*Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its 
corresponding river name
*/
SELECT PeakName, RiverName,
	LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName) - 1))) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix