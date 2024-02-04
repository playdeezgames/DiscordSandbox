CREATE VIEW [dbo].[EffectTypeDetails]
	AS
SELECT
	et.EffectTypeId,
	et.EffectTypeName
FROM
	EffectTypes et

