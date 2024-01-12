CREATE TABLE [dbo].[Recipes]
(
	[RecipeId] INT NOT NULL IDENTITY(1,1),
	RecipeName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Recipes PRIMARY KEY([RecipeId]),
	CONSTRAINT AK_Recipes_RecipeName UNIQUE(RecipeName)
)
