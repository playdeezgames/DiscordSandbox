CREATE VIEW [dbo].[ItemTypeGeneratorItemTypeDetails]
	AS 
SELECT
	itgit.ItemTypeGeneratorItemTypeId,
	it.ItemTypeId,
	it.ItemTypeName
FROM
	ItemTypeGeneratorItemTypes itgit
	JOIN ItemTypes it ON it.ItemTypeId = itgit.ItemTypeId
