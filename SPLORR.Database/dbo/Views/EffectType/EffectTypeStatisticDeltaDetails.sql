CREATE VIEW [dbo].[EffectTypeStatisticDeltaDetails]
	AS
SELECT
	etsd.EffectTypeStatisticDeltaId,
	etsd.EffectTypeId,
	etsd.StatisticTypeId,
	etsd.StatisticValue,
	et.EffectTypeName,
	st.StatisticTypeName
FROM
	EffectTypeStatisticDeltas etsd
	JOIN EffectTypes et ON etsd.EffectTypeId=et.EffectTypeId
	JOIN StatisticTypes st ON etsd.StatisticTypeId=st.StatisticTypeId
