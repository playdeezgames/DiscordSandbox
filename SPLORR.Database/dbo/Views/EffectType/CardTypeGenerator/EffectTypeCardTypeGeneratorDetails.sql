CREATE VIEW [dbo].[EffectTypeCardTypeGeneratorDetails]
	AS
SELECT
	etctg.EffectTypeCardTypeGeneratorId,
	etctg.CardCount,
	etctg.CardTypeGeneratorId,
	etctg.EffectTypeId,
	et.EffectTypeName,
	ctg.CardTypeGeneratorName
FROM
	EffectTypeCardTypeGenerators etctg
	JOIN EffectTypes et ON etctg.EffectTypeId=et.EffectTypeId
	JOIN CardTypeGenerators ctg on etctg.CardTypeGeneratorId=ctg.CardTypeGeneratorId
