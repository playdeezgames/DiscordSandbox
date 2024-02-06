CREATE VIEW [dbo].[LocationTypeDetails]
	AS
SELECT
	lt.LocationTypeId,
	lt.LocationTypeName
FROM
	LocationTypes lt
