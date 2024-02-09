CREATE VIEW [dbo].[CardStatisticDeltas]
	AS
SELECT
	c.CardId,
	etsd.StatisticTypeId,
	SUM(etsd.StatisticValue) StatisticValue
FROM
	Cards c
	JOIN Characters ch on c.CharacterId=ch.CharacterId
	JOIN Locations l ON ch.LocationId=l.LocationId
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypes et ON cte.EffectTypeId=et.EffectTypeId AND (et.LocationTypeId IS NULL OR et.LocationTypeId=l.LocationTypeId)
	JOIN EffectTypeStatisticDeltas etsd ON et.EffectTypeId=etsd.EffectTypeId
GROUP BY
	c.CardId,
	etsd.StatisticTypeId
