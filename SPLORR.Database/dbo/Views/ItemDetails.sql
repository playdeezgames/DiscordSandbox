CREATE VIEW [dbo].[ItemDetails]
	AS
SELECT
	i.ItemId,
	i.InventoryId,
	it.ItemTypeName as ItemName
FROM
	Items i
	JOIN ItemTypes it ON it.ItemTypeId = i.ItemTypeId
