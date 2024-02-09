CREATE VIEW [dbo].[EffectTypeStatisticRequirementDetails]
	AS
SELECT
	etsr.EffectTypeStatisticRequirementId,
	etsr.EffectTypeId,
	etsr.MaximumValue,
	etsr.MinimumValue,
	etsr.StatisticTypeId,
	et.EffectTypeName,
	st.StatisticTypeName
FROM
	EffectTypeStatisticRequirements etsr
	JOIN StatisticTypes st on etsr.StatisticTypeId=st.StatisticTypeId
	JOIN EffectTypes et ON etsr.EffectTypeId=et.EffectTypeId

