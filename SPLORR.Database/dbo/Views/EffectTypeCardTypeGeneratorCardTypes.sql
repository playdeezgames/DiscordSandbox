CREATE VIEW [dbo].[EffectTypeCardTypeGeneratorCardTypes]
	AS
SELECT
	etctg.EffectTypeCardTypeGeneratorId,
	ctgct.CardTypeGeneratorCardTypeId
FROM
	EffectTypeCardTypeGenerators etctg
	JOIN CardTypeGeneratorCardTypes ctgct ON etctg.CardTypeGeneratorId = ctgct.CardTypeGeneratorId
