CREATE VIEW [dbo].[LocationAvailableDirections]
	AS
SELECT
	l.LocationId,
	d.DirectionId,
	d.DirectionName
FROM
	Locations l
	CROSS JOIN Directions d
	LEFT JOIN [Routes] r ON r.DirectionId=d.DirectionId AND r.FromLocationId=l.LocationId
WHERE
	r.RouteId IS NULL;