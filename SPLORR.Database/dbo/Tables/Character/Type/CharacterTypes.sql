CREATE TABLE [dbo].[CharacterTypes]
(
	[CharacterTypeId] INT NOT NULL IDENTITY(1,1),
	[CharacterTypeName] NVARCHAR(100) NOT NULL,
	[IsPlayerSelectable] BIT NOT NULL CONSTRAINT DF_CharacterTypes_IsPlayerSelectable DEFAULT 0, 
    [GeneratorWeight] INT NOT NULL CONSTRAINT DF_CharacterTypes_GeneratorWeight DEFAULT 0, 
    CONSTRAINT PK_CharacterTypes PRIMARY KEY([CharacterTypeId]),
	CONSTRAINT AK_CharacterTypes_CharacterTypeName UNIQUE(CharacterTypeName)
)
