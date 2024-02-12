CREATE TABLE [dbo].[CardTypeStatisticRequirements]
(
	[CardTypeStatisticRequirementId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[StatisticTypeId] INT NOT NULL,
	[MinimumValue] INT NULL,
	[MaximumValue] INT NULL,
	CONSTRAINT PK_CardTypeStatisticRequirements PRIMARY KEY([CardTypeStatisticRequirementId]),
	CONSTRAINT FK_CardTypeStatisticRequirements_CardTypes FOREIGN KEY ([CardTypeId]) REFERENCES CardTypes([CardTypeId]),
	CONSTRAINT FK_CardTypeStatisticRequirements_StatisticTypes FOREIGN KEY ([StatisticTypeId]) REFERENCES StatisticTypes([StatisticTypeId]),
	CONSTRAINT AK_CardTypeStatisticRequirements_CardTypeId_StatisticTypeId UNIQUE(CardTypeId,StatisticTypeId),
	CONSTRAINT CK_CardTypeStatisticRequirements_MinimumValue_MaximumValue CHECK ((MinimumValue IS NOT NULL AND MaximumValue IS NOT NULL AND MinimumValue <= MaximumValue) OR (MinimumValue IS NULL and MaximumValue IS NOT NULL) OR (MaximumValue IS NULL and MinimumValue IS NOT NULL))
)
