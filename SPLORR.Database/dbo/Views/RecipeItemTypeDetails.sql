CREATE VIEW [dbo].[RecipeItemTypeDetails]
	AS
SELECT
	rit.RecipeItemTypeId,
	rit.RecipeId,
	rit.ItemTypeId,
	rit.QuantityIn,
	rit.QuantityOut,
	it.ItemTypeName,
	r.RecipeName
FROM
	RecipeItemTypes rit
	JOIN ItemTypes it ON rit.ItemTypeId=it.ItemTypeId
	JOIN Recipes r ON r.RecipeId=rit.RecipeId
