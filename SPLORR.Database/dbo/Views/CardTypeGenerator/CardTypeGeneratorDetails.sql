CREATE VIEW [dbo].[CardTypeGeneratorDetails]
	AS
SELECT
	ctg.CardTypeGeneratorId,
	ctg.CardTypeGeneratorName
FROM
	CardTypeGenerators ctg

