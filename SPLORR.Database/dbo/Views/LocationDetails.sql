CREATE VIEW [dbo].[LocationDetails]
	AS
SELECT
	l.LocationId,
	l.LocationName,
	l.LocationTypeId,
	lt.LocationTypeName
FROM
	Locations l
	JOIN LocationTypes lt ON l.LocationTypeId=lt.LocationTypeId
