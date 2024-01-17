CREATE TABLE [dbo].[Cards]
(
	[CardId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[CharacterId] INT NOT NULL,
	[InHand] BIT NOT NULL CONSTRAINT DF_Cards_InHand DEFAULT(0),
	[InDiscardPile] BIT NOT NULL CONSTRAINT DF_Cards_InDiscardPile DEFAULT(1),
	[InDrawPile] BIT NOT NULL CONSTRAINT DF_Cards_InDrawPile DEFAULT(0),
	[DrawOrder] INT NULL,
	CONSTRAINT PK_Cards PRIMARY KEY(CardId),
	CONSTRAINT FK_Cards_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT FK_Cards_Characters FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId),
	CONSTRAINT CK_Cards_InHand_InDrawPile_InDiscardPile_DrawOrder CHECK 
		(
			(InHand=1 AND InDiscardPile=0 AND InDrawPile=0 AND DrawOrder IS NULL) OR 
			(InHand=0 AND InDiscardPile=1 AND InDrawPile=0 AND DrawOrder IS NULL) OR 
			(InHand=0 AND InDiscardPile=0 AND InDrawPile=1 AND DrawOrder IS NOT NULL)
		)
);
