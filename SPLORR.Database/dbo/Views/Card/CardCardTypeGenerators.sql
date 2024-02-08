CREATE VIEW [dbo].[CardCardTypeGenerators]
	AS
SELECT
	c.CardId,
	etctg.CardTypeGeneratorId
FROM
	Cards c
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
	JOIN EffectTypeCardTypeGenerators etctg ON etctg.EffectTypeId=cte.EffectTypeId
