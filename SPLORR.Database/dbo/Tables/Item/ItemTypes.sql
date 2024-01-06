CREATE TABLE [dbo].[ItemTypes]
(
	[ItemTypeId] INT NOT NULL IDENTITY(1,1),
	[ItemTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeId),
	CONSTRAINT AK_ItemTypes_ItemTypeName UNIQUE(ItemTypeName)
)
