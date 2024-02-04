CREATE VIEW [dbo].[CardTypeStatisticRequirementDetails]
	AS
SELECT
	ctsr.CardTypeStatisticRequirementId,
	ctsr.CardTypeId,
	ctsr.MaximumValue,
	ctsr.MinimumValue,
	ctsr.StatisticTypeId,
	ct.CardTypeName,
	st.StatisticTypeName
FROM
	CardTypeStatisticRequirements ctsr
	JOIN StatisticTypes st on ctsr.StatisticTypeId=st.StatisticTypeId
	JOIN CardTypes ct ON ctsr.CardTypeId=ct.CardTypeId
