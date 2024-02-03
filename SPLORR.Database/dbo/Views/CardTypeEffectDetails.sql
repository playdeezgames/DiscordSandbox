CREATE VIEW [dbo].[CardTypeEffectDetails]
	AS
SELECT
	ct.CardTypeId,
	ct.CardTypeName,
	et.EffectTypeId,
	et.EffectTypeName,
	cte.CardTypeEffectId
FROM
	CardTypes ct
	CROSS JOIN EffectTypes et
	LEFT JOIN CardTypeEffects cte ON ct.CardTypeId=cte.CardTypeId AND et.EffectTypeId=cte.EffectTypeId
