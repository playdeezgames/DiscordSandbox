CREATE VIEW [dbo].[RecipeAvailableItemTypes]
	AS
SELECT
	r.RecipeId,
	it.ItemTypeId,
	it.ItemTypeName
FROM
	Recipes r
	CROSS JOIN ItemTypes it
	LEFT JOIN RecipeItemTypes rit ON r.RecipeId=rit.RecipeId and rit.ItemTypeId=it.ItemTypeId
WHERE
	rit.RecipeItemTypeId IS NULL;
