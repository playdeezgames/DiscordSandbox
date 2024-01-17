CREATE TABLE [dbo].[CharacterStatistics]
(
	[CharacterStatisticId] INT NOT NULL IDENTITY(1,1),
	CharacterId INT NOT NULL,
	StatisticTypeId INT NOT NULL,
	StatisticValue INT NOT NULL,
	CONSTRAINT PK_CharacterStatistics PRIMARY KEY (CharacterStatisticId),
	CONSTRAINT AK_CharacterStatistics_CharacterId_StatisticTypeId UNIQUE(CharacterId, StatisticTypeId),
	CONSTRAINT FK_CharacterStatistics_Characters FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId),
	CONSTRAINT FK_CharacterStatistics_StatisticTypes FOREIGN KEY (StatisticTypeId) REFERENCES StatisticTypes(StatisticTypeId)
)
