﻿CREATE VIEW [dbo].[EffectTypeDetails]
	AS
SELECT
	et.EffectTypeId,
	et.EffectTypeName,
	lt.LocationTypeId,
	lt.LocationTypeName,
	et.[RefreshHand]
FROM
	EffectTypes et
	LEFT JOIN LocationTypes lt ON lt.LocationTypeId=et.LocationTypeId

