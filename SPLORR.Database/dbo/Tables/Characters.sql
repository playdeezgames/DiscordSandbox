CREATE TABLE [dbo].[Characters] (
    [CharacterId]   INT            IDENTITY (1, 1) NOT NULL,
    [CharacterName] NVARCHAR (100) NOT NULL,
    [LocationId]    INT            NOT NULL,
    [CharacterTypeId] INT            NOT NULL,
    CONSTRAINT [PK_CharacterId] PRIMARY KEY CLUSTERED ([CharacterId] ASC),
    CONSTRAINT [FK_Characters_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([LocationId]),
    CONSTRAINT [FK_Characters_CharacterTypes] FOREIGN KEY ([CharacterTypeId]) REFERENCES [dbo].[CharacterTypes]([CharacterTypeId])
);

