CREATE TABLE [dbo].[EffectTypeCardTypeGenerators]
(
	[EffectTypeCardTypeGeneratorId] INT NOT NULL IDENTITY(1,1),
	[EffectTypeId] INT NOT NULL,
	[CardTypeGeneratorId] INT NOT NULL,
	[CardCount] INT NOT NULL,
	CONSTRAINT PK_EffectTypeCardTypeGenerators PRIMARY KEY (EffectTypeCardTypeGeneratorId),
	CONSTRAINT AK_EffectTypeCardTypeGenerators_EffectTypeId_CardTypeGeneratorId UNIQUE(EffectTypeId, CardTypeGeneratorId),
	CONSTRAINT FK_EffectTypeCardTypeGenerators_EffectTypes FOREIGN KEY (EffectTypeId) REFERENCES EffectTypes(EffectTypeId),
	CONSTRAINT FK_EffectTypeCardTypeGenerators_CardTypeGenerators FOREIGN KEY (CardTypeGeneratorId) REFERENCES CardTypeGenerators(CardTypeGeneratorId),
	CONSTRAINT CK_EffectTypeGardTypeGenerators_CardCount CHECK(CardCount>0)
)
