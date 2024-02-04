CREATE TABLE [dbo].[EffectTypeStatisticDeltas]
(
	[EffectTypeStatisticDeltaId] INT NOT NULL IDENTITY(1,1),
	EffectTypeId INT NOT NULL,
	StatisticTypeId INT NOT NULL,
	StatisticValue INT NOT NULL,
	CONSTRAINT PK_EffectTypeStatisticDeltas PRIMARY KEY(EffectTypeStatisticDeltaId),
	CONSTRAINT AK_EffectTypeStatisticDeltas_EffectTypeId_StatisticTypeId UNIQUE(EffectTypeId,StatisticTypeId),
	CONSTRAINT FK_EffectTypeStatisticDeltas_EffectTypes FOREIGN KEY (EffectTypeId) REFERENCES EffectTypes(EffectTypeId),
	CONSTRAINT FK_EffectTypeStatisticDeltas_StatisticTypes FOREIGN KEY (StatisticTypeId) REFERENCES StatisticTypes(StatisticTypeId),
	CONSTRAINT CK_EffectTypeStatisticDeltas_StatisticValue CHECK(StatisticValue<>0)
)
