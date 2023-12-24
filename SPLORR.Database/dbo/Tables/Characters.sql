CREATE TABLE [dbo].[Characters] (
    [CharacterId]   INT            IDENTITY (1, 1) NOT NULL,
    [CharacterName] NVARCHAR (100) NOT NULL,
    [LocationId]    INT            NOT NULL,
    [CharacterType] INT            NOT NULL,
    CONSTRAINT [PK_CharacterId] PRIMARY KEY CLUSTERED ([CharacterId] ASC),
    CONSTRAINT [FK_Characters_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([LocationId])
);

