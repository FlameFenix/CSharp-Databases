SELECT 
mc.CountryCode,
m.MountainRange,
p.PeakName,
p.Elevation
FROM Peaks AS p
JOIN MountainsCountries AS mc
ON mc.MountainId = p.MountainId
JOIN Mountains as m
ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC