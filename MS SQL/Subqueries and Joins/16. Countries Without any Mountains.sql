SELECT COUNT(*) AS [Count] FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL
