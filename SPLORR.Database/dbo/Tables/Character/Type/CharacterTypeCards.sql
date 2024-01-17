CREATE TABLE [dbo].[CharacterTypeCards]
(
	[CharacterTypeCardId] INT NOT NULL IDENTITY(1,1),
	[CharacterTypeId] INT NOT NULL,
	[CardTypeId] INT NOT NULL,
	[CardQuantity] INT NOT NULL,
	CONSTRAINT PK_CharacterTypeCards PRIMARY KEY (CharacterTypeCardId),
	CONSTRAINT AK_CharacterTypeCards_CharacterTypeId_CardTypeId UNIQUE(CharacterTypeId, CardTypeId),
	CONSTRAINT FK_CharacterTypeCards_CharacterTypes FOREIGN KEY (CharacterTypeId) REFERENCES CharacterTypes(CharacterTypeId),
	CONSTRAINT FK_CharacterTypeCards_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT CK_CharacterTypeCards_CardQuantity CHECK(CardQuantity>0)
);
