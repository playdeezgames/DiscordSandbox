CREATE VIEW [dbo].[CharacterTypeAvailableStatisticTypes]
	AS
SELECT
	ct.CharacterTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	CharacterTypes ct
	CROSS JOIN StatisticTypes st
	LEFT JOIN CharacterTypeStatistics cts ON cts.CharacterTypeId=ct.CharacterTypeId AND cts.StatisticTypeId=st.StatisticTypeId
WHERE
	cts.CharacterTypeStatisticId IS NULL