CREATE VIEW [dbo].[CardLocations]
	AS
SELECT
	c.CardId,
	etl.LocationId
FROM
	Cards c
	JOIN CardTypeEffects cte ON cte.CardTypeId = c.CardTypeId
	JOIN EffectTypeLocations etl ON etl.EffectTypeId = cte.EffectTypeId
