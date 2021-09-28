SELECT TOP (5) CountryName, RiverName FROM Countries AS c
FULL OUTER JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
FULL OUTER JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE ContinentCode IN ('AF')
ORDER BY CountryName