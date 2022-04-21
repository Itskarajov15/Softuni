/*
Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order
*/
SELECT c.CountryCode,
       m.MountainRange,
	   p.PeakName,
	   p.Elevation
	FROM Countries c
	JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
	JOIN Peaks p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

/*
Filter the count of the mountain ranges in the United States, Russia and Bulgaria
*/
SELECT c.CountryCode,
	   COUNT(*) AS MountainRanges 
	FROM Countries c
	JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN ('BG', 'RU', 'US')	
	GROUP BY c.CountryCode

/*
Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
*/
SELECT TOP(5)
		c.CountryName,
		r.RiverName
	FROM Countries c
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName

/*
Find all the count of all countries, which don’t have a mountain.
*/
SELECT COUNT(*) 
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

/*
find the elevation of the highest peak and the length of the longest river, 
sorted by the highest peak elevation, then by the longest river length, then by country name. 
Display NULL when no data is available in some of the columns. Limit only the first 5 rows
*/
SELECT TOP(5)
		c.CountryName,
		MAX(p.Elevation) AS HighestPeakElevation,
		MAX(r.[Length]) AS LongestRiverLength
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC,
			 LongestRiverLength DESC,
			 c.CountryName

/*
For each country, find the name and elevation of the highest peak, along with its mountain.
*/
SELECT	TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
	FROM(SELECT CountryName,
		ISNULL(p.PeakName, '(no highest peak)') AS PeakName,
		ISNULL(m.MountainRange, '(no mountain)') AS MountainRange,
		ISNULL(MAX(p.Elevation), 0) AS HighestPeak,
		DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS
			Ranked
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id	
	GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
	WHERE Ranked = 1
	ORDER BY CountryName, PeakName