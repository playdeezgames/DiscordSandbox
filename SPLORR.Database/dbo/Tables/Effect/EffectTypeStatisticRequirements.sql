CREATE TABLE [dbo].[EffectTypeStatisticRequirements]
(
	[EffectTypeStatisticRequirementId] INT NOT NULL IDENTITY(1,1),
	[EffectTypeId] INT NOT NULL,
	[StatisticTypeId] INT NOT NULL,
	[MinimumValue] INT NULL,
	[MaximumValue] INT NULL,
	CONSTRAINT PK_EffectTypeStatisticRequirements PRIMARY KEY([EffectTypeStatisticRequirementId]),
	CONSTRAINT FK_EffectTypeStatisticRequirements_EffectTypes FOREIGN KEY ([EffectTypeId]) REFERENCES EffectTypes([EffectTypeId]),
	CONSTRAINT FK_EffectTypeStatisticRequirements_StatisticTypes FOREIGN KEY ([StatisticTypeId]) REFERENCES StatisticTypes([StatisticTypeId]),
	CONSTRAINT AK_EffectTypeStatisticRequirements_EffectTypeId_StatisticTypeId UNIQUE(EffectTypeId,StatisticTypeId),
	CONSTRAINT CK_EffectTypeStatisticRequirements_MinimumValue_MaximumValue CHECK ((MinimumValue IS NOT NULL AND MaximumValue IS NOT NULL AND MinimumValue <= MaximumValue) OR (MinimumValue IS NULL and MaximumValue IS NOT NULL) OR (MaximumValue IS NULL and MinimumValue IS NOT NULL))
)
