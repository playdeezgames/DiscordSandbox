CREATE TABLE [dbo].[LocationTypes]
(
	[LocationTypeId] INT NOT NULL IDENTITY(1,1),
	[LocationTypeName] NVARCHAR(100) NOT NULL,
	[ItemTypeGeneratorId] INT NULL, 
    CONSTRAINT PK_LocationTypes PRIMARY KEY(LocationTypeId),
	CONSTRAINT AK_LocationTypes_LocationTypeName UNIQUE(LocationTypeName),
	CONSTRAINT FK_LocationTYpes_ItemTypeGenerators FOREIGN KEY (ItemTypeGeneratorId) REFERENCES ItemTypeGenerators(ItemTypeGeneratorId)
)
