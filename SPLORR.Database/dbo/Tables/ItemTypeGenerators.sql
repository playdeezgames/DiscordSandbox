CREATE TABLE [dbo].[ItemTypeGenerators]
(
	[ItemTypeGeneratorId] INT NOT NULL IDENTITY(1,1),
	[ItemTypeGeneratorName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_ItemTypeGenerators PRIMARY KEY(ItemTypeGeneratorId),
	CONSTRAINT AK_ItemTypeGenerators_ItemTypeGeneratorName UNIQUE(ItemTypeGeneratorName)
)
