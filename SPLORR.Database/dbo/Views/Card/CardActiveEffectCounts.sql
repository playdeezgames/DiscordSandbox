CREATE VIEW [dbo].[CardActiveEffectCounts]
	AS
SELECT
	c.CardId,
	COUNT(et.EffectTypeId) EffectCount
FROM
	Cards c
	JOIN Characters ch on c.CharacterId=ch.CharacterId
	JOIN Locations l ON ch.LocationId=l.LocationId
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypes et ON cte.EffectTypeId=et.EffectTypeId AND (et.LocationTypeId IS NULL OR et.LocationTypeId=l.LocationTypeId)
GROUP BY
	c.CardId
