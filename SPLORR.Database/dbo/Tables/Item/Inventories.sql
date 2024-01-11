CREATE TABLE [dbo].[Inventories] (
    [InventoryId] INT IDENTITY (1, 1) NOT NULL,
    [CharacterId] INT NULL,
    [LocationId]  INT NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED ([InventoryId] ASC),
    CONSTRAINT [CK_Inventoreis_CharacterId_LocationId] CHECK ([CharacterId] IS NULL AND [LocationId] IS NOT NULL OR [CharacterId] IS NOT NULL AND [LocationId] IS NULL),
    CONSTRAINT [FK_Inventories_Characters] FOREIGN KEY ([CharacterId]) REFERENCES [dbo].[Characters] ([CharacterId]),
    CONSTRAINT [FK_Inventories_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([LocationId])
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_Inventories_LocationID]
    ON [dbo].[Inventories]([LocationId] ASC) WHERE ([LocationId] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_Inventories_CharacterID]
    ON [dbo].[Inventories]([CharacterId] ASC) WHERE ([CharacterId] IS NOT NULL);

