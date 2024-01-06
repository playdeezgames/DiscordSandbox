CREATE VIEW [dbo].[ItemNames]
	AS
SELECT
	i.ItemId,
	it.ItemTypeName as ItemName
FROM
	Items i
	JOIN ItemTypes it ON it.ItemTypeId = i.ItemTypeId
