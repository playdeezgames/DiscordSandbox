CREATE VIEW [dbo].[CardEffectTypes]
	AS
SELECT
	c.CardId,
	cte.EffectTypeId
FROM
	Cards c
	JOIN CardTypeEffects cte ON cte.CardTypeId=c.CardTypeId
