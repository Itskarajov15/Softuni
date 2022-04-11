--Display all mountain peaks in alphabetical order
SELECT PeakName 
	FROM Peaks
	ORDER BY PeakName ASC

--Find the 30 biggest countries by population from Europe and sort the results by population, then by country alphabetically.
SELECT TOP(30) CountryName, [Population]
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY [Population] DESC,
			 CountryName ASC

--Display the country name, country code and information about its currency: either "Euro" or "Not Euro" and sort them
SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS Currency
	FROM Countries
	ORDER BY CountryName ASC