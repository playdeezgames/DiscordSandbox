CREATE VIEW [dbo].[LocationTypeAvailableVerbTypes]
	AS
SELECT
	lt.LocationTypeId,
	vt.VerbTypeId,
	ltvt.LocationTypeVerbTypeId
FROM
	LocationTypes lt
	CROSS JOIN VerbTypes vt
	LEFT JOIN LocationTypeVerbTypes ltvt ON lt.LocationTypeId=ltvt.LocationTypeId AND vt.VerbTypeId=ltvt.VerbTypeId
