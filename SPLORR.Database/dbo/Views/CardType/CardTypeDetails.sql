CREATE VIEW [dbo].[CardTypeDetails]
	AS 
SELECT
	ct.CardTypeId,
	ct.CardTypeName,
	COUNT(c.CardId) CardCount,
	ct.SelfDestruct,
	ct.CardLimit,
	ct.AlwaysAvailable
FROM
	CardTypes ct
	LEFT JOIN Cards c ON c.CardTypeId=ct.CardTypeId
GROUP BY
	ct.CardTypeId,
	ct.CardTypeName,
	ct.SelfDestruct,
	ct.CardLimit,
	ct.AlwaysAvailable
