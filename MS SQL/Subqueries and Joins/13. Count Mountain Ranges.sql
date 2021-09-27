SELECT CountryCode, COUNT(CountryCode) AS MountainRanges FROM MountainsCountries
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode
ORDER BY MountainRanges DESC


