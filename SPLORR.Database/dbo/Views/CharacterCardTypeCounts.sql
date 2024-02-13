CREATE VIEW [dbo].[CharacterCardTypeCounts]
	AS
SELECT
	c.CharacterId,
	c.CardTypeId,
	COUNT(c.CardId) CardCount
FROM
	Cards c
GROUP BY 
	c.CharacterId,
	c.CardTypeId
