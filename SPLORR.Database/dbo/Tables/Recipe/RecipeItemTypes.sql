CREATE TABLE [dbo].[RecipeItemTypes]
(
	[RecipeItemTypeId] INT NOT NULL IDENTITY(1,1),
	[RecipeId] INT NOT NULL,
	[ItemTypeId] INT NOT NULL,
	[QuantityIn] INT NOT NULL,
	[QuantityOut] INT NOT NULL,
	CONSTRAINT PK_RecipeItemTypes PRIMARY KEY([RecipeItemTypeId]),
	CONSTRAINT FK_RecipeItemTypes_Recipes FOREIGN KEY ([RecipeId]) REFERENCES [Recipes]([RecipeId]),
	CONSTRAINT FK_RecipeItemTypes_ItemTypes FOREIGN KEY (ItemTypeId) REFERENCES ItemTypes(ItemTypeId),
	CONSTRAINT CK_RecipeItemTypes_QuantityIn CHECK(QuantityIn>=0),
	CONSTRAINT CK_RecipeItemTypes_QuantityOut CHECK(QuantityOut>=0),
	CONSTRAINT CK_RecipeItemTypes_QuantityIn_QuantityOut CHECK(QuantityIn+QuantityOut>0),
	CONSTRAINT AK_RecipeItemTypes_RecipeId_ItemTypeId UNIQUE([RecipeId], ItemTypeId)
)
