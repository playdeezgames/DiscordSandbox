﻿CREATE TABLE [dbo].[CharacterTypeStatistics]
(
	[CharacterTypeStatisticId] INT NOT NULL IDENTITY(1,1),
	CharacterTypeId INT NOT NULL,
	StatisticTypeId INT NOT NULL,
	StatisticValue INT NOT NULL,
	CONSTRAINT PK_CharacterTypeStatistics PRIMARY KEY (CharacterTypeStatisticId),
	CONSTRAINT AK_CharacterTypeStatistics_CharacterTypeId_StatisticTypeId UNIQUE(CharacterTypeId, StatisticTypeId),
	CONSTRAINT FK_CharacterTypeStatistics_CharacterTypes FOREIGN KEY (CharacterTypeId) REFERENCES CharacterTypes(CharacterTypeId),
	CONSTRAINT FK_CharacterTypeStatistics_StatisticTypes FOREIGN KEY (StatisticTypeId) REFERENCES StatisticTypes(StatisticTypeId)
)
