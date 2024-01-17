CREATE VIEW [dbo].[CharacterAvailableStatistics]
	AS
SELECT
	c.CharacterId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	Characters c
	CROSS JOIN StatisticTypes st
	LEFT JOIN CharacterStatistics cs ON cs.StatisticTypeId = st.StatisticTypeId AND cs.CharacterId=c.CharacterId
WHERE
	cs.CharacterStatisticId IS NULL
