CREATE TABLE [dbo].[CharacterTypes]
(
	[CharacterTypeId] INT NOT NULL IDENTITY(1,1),
	[CharacterTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_CharacterTypes PRIMARY KEY([CharacterTypeId])
)
