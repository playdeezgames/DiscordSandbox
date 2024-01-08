CREATE TABLE [dbo].[ItemTypeGenerators]
(
	[ItemTypeGeneratorId] INT NOT NULL IDENTITY(1,1),
	[ItemTypeGeneratorName] NVARCHAR(100) NOT NULL,
	[NothingGeneratorWeight] INT NOT NULL, 
    CONSTRAINT PK_ItemTypeGenerators PRIMARY KEY(ItemTypeGeneratorId),
	CONSTRAINT AK_ItemTypeGenerators_ItemTypeGeneratorName UNIQUE(ItemTypeGeneratorName),
	CONSTRAINT CK_ItemTypeGenerators_NothingGeneratorWeight CHECK(NothingGeneratorWeight>=0)
)
