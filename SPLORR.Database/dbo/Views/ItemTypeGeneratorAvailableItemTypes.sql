CREATE VIEW [dbo].[ItemTypeGeneratorAvailableItemTypes]
	AS
SELECT
	itg.ItemTypeGeneratorId,
	it.ItemTypeId,
	it.ItemTypeName
FROM
	ItemTypeGenerators itg
	CROSS JOIN ItemTypes it
	LEFT JOIN ItemTypeGeneratorItemTypes itgit ON itg.ItemTypeGeneratorId=itgit.ItemTypeGeneratorId AND it.ItemTypeId=itgit.ItemTypeId
WHERE
	itgit.ItemTypeGeneratorItemTypeId IS NULL
