CREATE VIEW [dbo].[CharacterStatisticDetails]
	AS
SELECT
	cs.CharacterStatisticId,
	cs.CharacterId,
	st.StatisticTypeName
FROM
	CharacterStatistics cs
	JOIN StatisticTypes st ON cs.StatisticTypeId=st.StatisticTypeId
