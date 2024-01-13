CREATE VIEW [dbo].[InventoryItemTypeCounts]
	AS
SELECT
	i.InventoryId,
	i.ItemTypeId,
	COUNT(i.ItemId) ItemTypeCount
FROM
	Items i
GROUP BY 
	i.InventoryId,
	i.ItemTypeId;
