CREATE VIEW [dbo].[CardTypeGeneratorCardTypeDetails]
	AS
SELECT
	ctgct.CardTypeGeneratorCardTypeId,
	ctgct.CardTypeGeneratorId,
	ctgct.CardTypeId,
	ct.CardTypeName
FROM
	CardTypeGeneratorCardTypes ctgct
	JOIN CardTypes ct ON ctgct.CardTypeId=ct.CardTypeId
