CREATE VIEW [dbo].[CharacterDetails]
	AS
SELECT
	c.CharacterId,
	c.CharacterName,
	c.CharacterTypeId,
	c.LocationId,
	c.LastModified,
	ct.CharacterTypeName,
	l.LocationName
FROM
	Characters c
	JOIN CharacterTypes ct ON c.CharacterTypeId=ct.CharacterTypeId
	JOIN Locations l ON c.LocationId=l.LocationId
