CREATE VIEW [dbo].[EffectTypeAvailableCardTypeGenerators]
	AS
SELECT
	et.EffectTypeId,
	et.EffectTypeName,
	ctg.CardTypeGeneratorId,
	ctg.CardTypeGeneratorName
FROM
	EffectTypes et
	CROSS JOIN CardTypeGenerators ctg
	LEFT JOIN EffectTypeCardTypeGenerators etctg ON etctg.CardTypeGeneratorId=ctg.CardTypeGeneratorId AND etctg.EffectTypeId=et.EffectTypeId
WHERE
	etctg.EffectTypeCardTypeGeneratorId IS NULL;
