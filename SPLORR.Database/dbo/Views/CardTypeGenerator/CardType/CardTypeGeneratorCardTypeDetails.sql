CREATE VIEW [dbo].[CardTypeGeneratorCardTypeDetails]
	AS
SELECT
	ctgct.CardTypeGeneratorCardTypeId,
	ctgct.CardTypeGeneratorId,
	ctgct.CardTypeId,
	ctgct.GeneratorWeight,
	ct.CardTypeName,
	ctg.CardTypeGeneratorName
FROM
	CardTypeGeneratorCardTypes ctgct
	JOIN CardTypes ct ON ctgct.CardTypeId=ct.CardTypeId
	JOIN CardTypeGenerators ctg ON ctgct.CardTypeGeneratorId=ctg.CardTypeGeneratorId
