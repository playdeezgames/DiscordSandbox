CREATE TABLE [dbo].[Inventories]
(
	[InventoryId] INT NOT NULL IDENTITY(1,1),
	[CharacterId] INT NULL,
	[LocationId] INT NULL,
	CONSTRAINT PK_Inventories PRIMARY KEY(InventoryId),
	CONSTRAINT AK_Inventories_CharacterId UNIQUE(CharacterId),
	CONSTRAINT AK_Inventories_LocationId UNIQUE(LocationId),
	CONSTRAINT FK_Inventories_Characters FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId),
	CONSTRAINT FK_Inventories_Locations FOREIGN KEY (LocationId) REFERENCES Locations(LocationId),
	CONSTRAINT CK_Inventoreis_CharacterId_LocationId CHECK((CharacterId IS NULL AND LocationId IS NOT NULL) OR (CharacterId IS NOT NULL AND LocationId IS NULL))

)
