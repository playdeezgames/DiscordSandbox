CREATE VIEW [dbo].[CharacterTypeStatisticDetails]
	AS
SELECT
	cts.CharacterTypeStatisticId,
	cts.CharacterTypeId,
	cts.MaximumValue,
	cts.MinimumValue,
	cts.StatisticValue,
	cts.StatisticTypeId,
	st.StatisticTypeName,
	ct.CharacterTypeName
FROM
	CharacterTypeStatistics cts
	JOIN StatisticTypes st ON cts.StatisticTypeId = st.StatisticTypeId
	JOIN CharacterTypes ct ON cts.CharacterTypeId = ct.CharacterTypeId
