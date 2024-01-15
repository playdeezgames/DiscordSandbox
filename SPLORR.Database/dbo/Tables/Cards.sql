CREATE TABLE [dbo].[Cards]
(
	[CardId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[CharacterId] INT NOT NULL,
	CONSTRAINT PK_Cards PRIMARY KEY(CardId),
	CONSTRAINT FK_Cards_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT FK_Cards_Characters FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId) 
)
