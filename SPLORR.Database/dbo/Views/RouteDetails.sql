CREATE VIEW [dbo].[RouteDetails]
	AS
SELECT
	r.RouteId,
	r.FromLocationId,
	d.DirectionName
FROM
	Routes r
	JOIN Directions d ON d.DirectionId=r.DirectionId
