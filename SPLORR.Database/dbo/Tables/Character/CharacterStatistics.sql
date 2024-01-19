CREATE TABLE [dbo].[CharacterStatistics]
(
	[CharacterStatisticId] INT NOT NULL IDENTITY(1,1),
	CharacterId INT NOT NULL,
	StatisticTypeId INT NOT NULL,
	StatisticValue INT NOT NULL,
	[MinimumValue] INT NULL, 
    [MaximumValue] INT NULL,
	CONSTRAINT PK_CharacterStatistics PRIMARY KEY (CharacterStatisticId),
	CONSTRAINT AK_CharacterStatistics_CharacterId_StatisticTypeId UNIQUE(CharacterId, StatisticTypeId),
	CONSTRAINT FK_CharacterStatistics_Characters FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId),
	CONSTRAINT FK_CharacterStatistics_StatisticTypes FOREIGN KEY (StatisticTypeId) REFERENCES StatisticTypes(StatisticTypeId),
	CONSTRAINT CK_CharacterStatistics_StatisticValue CHECK ((MinimumValue IS NULL OR StatisticValue>=MinimumValue) AND (MaximumValue IS NULL OR StatisticValue<=MaximumValue)),
	CONSTRAINT CK_CharacterStatistics_MaximumValue CHECK (MinimumValue IS NULL OR MaximumValue IS NULL OR MinimumValue <= MaximumValue)
)
