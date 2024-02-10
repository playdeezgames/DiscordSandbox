CREATE VIEW [dbo].[CardStatisticRequirements]
	AS
SELECT
	c.CardId,
	etsr.StatisticTypeId,
	SUM(etsr.MinimumValue) MinimumValue,
	MIN(etsr.MaximumValue) MaximumValue
FROM
	Cards c
	JOIN Characters ch on c.CharacterId=ch.CharacterId
	JOIN Locations l ON ch.LocationId=l.LocationId
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypes et ON cte.EffectTypeId=et.EffectTypeId AND (et.LocationTypeId IS NULL OR et.LocationTypeId=l.LocationTypeId)
	JOIN EffectTypeStatisticRequirements etsr ON et.EffectTypeId=etsr.EffectTypeId
GROUP BY
	c.CardId,
	etsr.StatisticTypeId

