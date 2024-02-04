CREATE VIEW [dbo].[CardTypeAvailableRequirementStatisticTypes]
	AS
SELECT
	ct.CardTypeId,
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	CardTypes ct
	CROSS JOIN StatisticTypes st
	LEFT JOIN CardTypeStatisticRequirements ctsr ON ctsr.CardTypeId=ct.CardTypeId AND ctsr.StatisticTypeId=st.StatisticTypeId
WHERE
	ctsr.CardTypeStatisticRequirementId IS NULL;

