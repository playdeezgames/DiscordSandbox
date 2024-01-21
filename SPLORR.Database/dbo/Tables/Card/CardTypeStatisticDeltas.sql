CREATE TABLE [dbo].[CardTypeStatisticDeltas]
(
	[CardTypeStatisticDeltaId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[StatisticTypeId] INT NOT NULL,
	[StatisticDelta] INT NOT NULL,
	[AllowOverage] BIT NOT NULL,
	CONSTRAINT PK_CardTypeStatisticDeltas PRIMARY KEY(CardTypeStatisticDeltaId),
	CONSTRAINT AK_CardTypeStatisticDeltas_CardTypeId_StatisticTypeId UNIQUE(CardTypeId, StatisticTypeId),
	CONSTRAINT FK_CardTypeStatisticDeltas_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId),
	CONSTRAINT FK_CardTypeStatisticDeltas_StatisticTypes FOREIGN KEY (StatisticTypeId) REFERENCES StatisticTypes(StatisticTypeId),
	CONSTRAINT CK_CardTypeStatisticDeltas_StatisticDelta CHECK(StatisticDelta<>0)
)
