CREATE TABLE [dbo].[VerbTypes]
(
	[VerbTypeId] INT NOT NULL IDENTITY(1,1),
	[VerbTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_VerbTypes PRIMARY KEY([VerbTypeId]),
	CONSTRAINT AK_VerbTypes_VerbTypeName UNIQUE([VerbTypeName])
)
