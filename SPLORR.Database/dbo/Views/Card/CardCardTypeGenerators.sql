CREATE VIEW [dbo].[CardCardTypeGenerators]
	AS
SELECT
	c.CardId,
	etctg.CardTypeGeneratorId
FROM
	Cards c
	JOIN Characters ch on c.CharacterId=ch.CharacterId
	JOIN Locations l ON ch.LocationId=l.LocationId
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypes et ON cte.EffectTypeId=et.EffectTypeId AND (et.LocationTypeId IS NULL OR et.LocationTypeId=l.LocationTypeId)
	JOIN EffectTypeCardTypeGenerators etctg ON etctg.EffectTypeId=et.EffectTypeId
