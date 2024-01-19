CREATE TABLE [dbo].[PlayerCharacters] (
    [PlayerId]    INT NOT NULL,
    [CharacterId] INT NOT NULL,
    [PlayerCharacterId] INT NOT NULL IDENTITY(1,1),
    CONSTRAINT [PK_PlayerCharacters] PRIMARY KEY CLUSTERED ([PlayerId] ASC),
    CONSTRAINT [FK_PlayerCharacters_Characters] FOREIGN KEY ([CharacterId]) REFERENCES [dbo].[Characters] ([CharacterId]),
    CONSTRAINT [FK_PlayerCharacters_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([PlayerId]),
    CONSTRAINT [AK_PlayerCharacters_CharacterId] UNIQUE NONCLUSTERED ([CharacterId] ASC)
);

