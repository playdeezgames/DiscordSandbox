CREATE VIEW [dbo].[CardTypeAvailableStatisticDeltas]
	AS
SELECT
	ct.CardTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	CardTypes ct
	CROSS JOIN StatisticTypes st
	LEFT JOIN CardTypeStatisticDeltas ctsd ON ctsd.CardTypeId=ct.CardTypeId AND ctsd.StatisticTypeId=st.StatisticTypeId
WHERE
	ctsd.CardTypeStatisticDeltaId IS NULL
