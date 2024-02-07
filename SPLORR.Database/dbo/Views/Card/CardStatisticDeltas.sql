CREATE VIEW [dbo].[CardStatisticDeltas]
	AS
SELECT
	c.CardId,
	etsd.StatisticTypeId,
	SUM(etsd.StatisticValue) StatisticValue
FROM
	Cards c
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypeStatisticDeltas etsd ON cte.EffectTypeId=etsd.EffectTypeId
GROUP BY
	c.CardId,
	etsd.StatisticTypeId
