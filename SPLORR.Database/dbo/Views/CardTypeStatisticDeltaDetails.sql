CREATE VIEW [dbo].[CardTypeStatisticDeltaDetails]
	AS
SELECT
	ctsd.CardTypeStatisticDeltaId,
	ctsd.CardTypeId,
	st.StatisticTypeName
FROM
	CardTypeStatisticDeltas ctsd
	JOIN StatisticTypes st on ctsd.StatisticTypeId=st.StatisticTypeId
