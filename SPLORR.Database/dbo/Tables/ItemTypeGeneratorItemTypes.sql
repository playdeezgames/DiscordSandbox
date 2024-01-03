CREATE TABLE [dbo].[ItemTypeGeneratorItemTypes]
(
	[ItemTypeGeneratorItemTypeId] INT NOT NULL IDENTITY(1,1),
	[ItemTypeGeneratorId] INT NOT NULL,
	[ItemTypeId] INT NULL,
	[GeneratorWeight] INT NOT NULL,
	CONSTRAINT PK_ItemTypeGeneratorItemTypes PRIMARY KEY(ItemTypeGeneratorItemTypeId),
	CONSTRAINT AK_ItemTypeGeneratorItemTypes_ItemTypeGeneratorId_ItemTypeId UNIQUE(ItemTypeGeneratorId, ItemTypeId),
	CONSTRAINT CK_ItemTypeGeneratorItemTypes_GeneratorWeight CHECK(GeneratorWeight>0)
)
