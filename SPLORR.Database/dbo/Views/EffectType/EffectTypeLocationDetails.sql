CREATE VIEW [dbo].[EffectTypeLocationDetails]
	AS
SELECT
	etl.EffectTypeId,
	etl.LocationId,
	etl.EffectTypeLocationId,
	l.LocationName,
	et.EffectTypeName
FROM
	EffectTypeLocations etl
	JOIN EffectTypes et ON etl.EffectTypeId = et.EffectTypeId
	JOIN Locations l ON etl.LocationId=l.LocationId