CREATE VIEW [dbo].[StatisticTypeDetails]
	AS
SELECT
	st.StatisticTypeId,
	st.StatisticTypeName
FROM
	StatisticTypes st

