CREATE TABLE [dbo].[Items]
(
	[ItemId] INT NOT NULL IDENTITY(1,1),
	[InventoryId] INT NOT NULL,
	[ItemTypeId] INT NOT NULL,
	CONSTRAINT PK_Items PRIMARY KEY(ItemId),
	CONSTRAINT FK_Items_Inventories FOREIGN KEY(InventoryId) REFERENCES Inventories(InventoryId),
	CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeId) REFERENCES ItemTypes(ItemTypeId)
)
