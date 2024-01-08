CREATE VIEW [dbo].[ItemTypeGeneratorItemTypeDetails]
	AS 
SELECT
	itgit.ItemTypeGeneratorItemTypeId,
	it.ItemTypeId,
	it.ItemTypeName,
	itgit.GeneratorWeight
FROM
	ItemTypeGeneratorItemTypes itgit
	JOIN ItemTypes it ON it.ItemTypeId = itgit.ItemTypeId
