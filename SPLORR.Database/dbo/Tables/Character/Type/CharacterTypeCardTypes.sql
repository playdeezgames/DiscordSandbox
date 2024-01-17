CREATE TABLE [dbo].[CharacterTypeCardTypes]
(
	[CharacterTypeCardTypeId] INT NOT NULL IDENTITY(1,1),
	[CharacterTypeId] INT NOT NULL,
	[CardTypeId] INT NOT NULL,
	[CardQuantity] INT NOT NULL,
	CONSTRAINT PK_CharacterTypeCardTypes PRIMARY KEY (CharacterTypeCardTypeId),
	CONSTRAINT AK_CharacterTypeCardTypes_CharacterTypeId_CardTypeId UNIQUE(CharacterTypeId, CardTypeId),
	CONSTRAINT FK_CharacterTypeCardTypes_CharacterTypes FOREIGN KEY (CharacterTypeId) REFERENCES CharacterTypes(CharacterTypeId),
	CONSTRAINT FK_CharacterTypeCardTypes_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT CK_CharacterTypeCardTypes_CardQuantity CHECK(CardQuantity>0)
);
