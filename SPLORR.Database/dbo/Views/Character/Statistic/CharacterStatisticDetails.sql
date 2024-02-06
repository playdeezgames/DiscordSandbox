CREATE VIEW [dbo].[CharacterStatisticDetails]
	AS
SELECT
	cs.CharacterStatisticId,
	cs.CharacterId,
	st.StatisticTypeName,
	cs.StatisticValue,
	cs.MinimumValue,
	cs.MaximumValue,
	c.CharacterName
FROM
	CharacterStatistics cs
	JOIN StatisticTypes st ON cs.StatisticTypeId = st.StatisticTypeId
	JOIN Characters c ON cs.CharacterId = c.CharacterId
