CREATE TABLE [dbo].[LocationTypes]
(
	[LocationTypeId] INT NOT NULL IDENTITY(1,1),
	[LocationTypeName] NVARCHAR(100) NOT NULL, 
    CONSTRAINT PK_LocationTypes PRIMARY KEY(LocationTypeId),
	CONSTRAINT AK_LocationTypes_LocationTypeName UNIQUE(LocationTypeName)
)
