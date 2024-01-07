CREATE VIEW [dbo].[ItemTypeGeneratorAvailableItemTypes]
	AS
SELECT
	itg.ItemTypeGeneratorId,
	it.ItemTypeId,
	itgit.ItemTypeGeneratorItemTypeId
FROM
	ItemTypeGenerators itg
	CROSS JOIN ItemTypes it
	LEFT JOIN ItemTypeGeneratorItemTypes itgit ON itg.ItemTypeGeneratorId=itgit.ItemTypeGeneratorId AND it.ItemTypeId=itgit.ItemTypeId
