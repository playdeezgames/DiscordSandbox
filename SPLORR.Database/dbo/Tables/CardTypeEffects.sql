CREATE TABLE [dbo].[CardTypeEffects]
(
	[CardTypeEffectId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[EffectTypeId] INT NOT NULL,
	CONSTRAINT PK_CardTypeEffects PRIMARY KEY(CardTypeEffectId),
	CONSTRAINT FK_CardTypeEffects_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT FK_CardTypeEffects_EffectTypes FOREIGN KEY (EffectTypeId) REFERENCES EffectTypes(EffectTypeId),
	CONSTRAINT AK_CardTypeEffects_CardTypeId_EffectTypeId UNIQUE(CardTypeId, EffectTypeId)
)
