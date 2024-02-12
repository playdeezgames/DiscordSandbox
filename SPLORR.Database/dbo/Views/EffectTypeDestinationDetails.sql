CREATE VIEW [dbo].[EffectTypeDestinationDetails]
	AS
SELECT
	etl.EffectTypeId,
	etl.LocationId,
	COUNT(etl.EffectTypeLocationId) GeneratorWeight
FROM
	EffectTypeLocations etl
GROUP BY
	etl.EffectTypeId,
	etl.LocationId
