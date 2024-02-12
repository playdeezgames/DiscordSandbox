CREATE VIEW [dbo].[CharacterLocationOtherCharacters]
	AS 
SELECT 
	c.CharacterId,
	oc.CharacterId AS OtherCharacterId 
FROM
	Characters c
	JOIN Characters oc ON c.LocationId=oc.LocationId AND c.CharacterId<>oc.CharacterId
