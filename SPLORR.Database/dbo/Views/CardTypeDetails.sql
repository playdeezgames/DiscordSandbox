CREATE VIEW [dbo].[CardTypeDetails]
	AS 
SELECT
	ct.CardTypeId,
	ct.CardTypeName,
	COUNT(c.CardId) CardCount
FROM
	CardTypes ct
	LEFT JOIN Cards c ON c.CardTypeId=ct.CardTypeId
GROUP BY
	ct.CardTypeId,
	ct.CardTypeName
