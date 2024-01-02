CREATE VIEW [dbo].[CharacterAvailableVerbTypes]
	AS
SELECT
	c.CharacterId,
	ltvt.VerbTypeId
FROM
	Characters c
	JOIN Locations l ON c.LocationId=l.LocationId
	JOIN LocationTypeVerbTypes ltvt on ltvt.LocationTypeId=l.LocationTypeId