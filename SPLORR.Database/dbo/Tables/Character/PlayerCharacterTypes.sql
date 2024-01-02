CREATE TABLE [dbo].[PlayerCharacterTypes]
(
	[CharacterTypeId] INT NOT NULL,
	[GeneratorWeight] INT NOT NULL,
	CONSTRAINT PK_PlayerCharacterTypes PRIMARY KEY ([CharacterTypeId]),
	CONSTRAINT CK_PlayerCharacterTypes_GeneratorWeight CHECK ([GeneratorWeight]>0),
	CONSTRAINT FK_PlayerCharacterTypes_CharacterTypes FOREIGN KEY ([CharacterTypeId]) REFERENCES [CharacterTypes]([CharacterTypeId])
)
