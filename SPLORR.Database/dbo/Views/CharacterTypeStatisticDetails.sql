CREATE VIEW [dbo].[CharacterTypeStatisticDetails]
	AS
SELECT
	cts.CharacterTypeStatisticId,
	cts.CharacterTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	CharacterTypeStatistics cts
	JOIN StatisticTypes st on cts.StatisticTypeId=st.StatisticTypeId
