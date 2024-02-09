CREATE VIEW [dbo].[EffectTypeAvailableRequirementStatisticTypes]
	AS
SELECT
	et.EffectTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	EffectTypes et
	CROSS JOIN StatisticTypes st
	LEFT JOIN EffectTypeStatisticRequirements etsr ON etsr.EffectTypeId=et.EffectTypeId AND etsr.StatisticTypeId=st.StatisticTypeId
WHERE
	etsr.EffectTypeStatisticRequirementId IS NULL;

