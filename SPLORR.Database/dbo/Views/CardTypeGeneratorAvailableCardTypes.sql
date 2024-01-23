CREATE VIEW [dbo].[CardTypeGeneratorAvailableCardTypes]
	AS
SELECT
	ctg.CardTypeGeneratorId,
	ct.CardTypeId,
	ct.CardTypeName
FROM
	CardTypeGenerators ctg
	CROSS JOIN CardTypes ct
	LEFT JOIN CardTypeGeneratorCardTypes ctgct ON ctgct.CardTypeGeneratorId=ctg.CardTypeGeneratorId AND ctgct.CardTypeId=ct.CardTypeId
WHERE
	ctgct.CardTypeGeneratorCardTypeId IS NULL
