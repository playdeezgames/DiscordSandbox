CREATE VIEW [dbo].[EffectTypeAvailableDeltaStatisticTypes]
	AS
SELECT
	et.EffectTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	EffectTypes et
	CROSS JOIN StatisticTypes st
	LEFT JOIN EffectTypeStatisticDeltas etsd ON etsd.StatisticTypeId = st.StatisticTypeId AND etsd.EffectTypeId=et.EffectTypeId
WHERE
	etsd.EffectTypeStatisticDeltaId IS NULL;
