CREATE TABLE [dbo].[StatisticTypes]
(
	[StatisticTypeId] INT NOT NULL IDENTITY(1,1),
	[StatisticTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_StatisticTypes PRIMARY KEY(StatisticTypeId),
	CONSTRAINT AK_StatisticTypes_StatisticTypeName UNIQUE(StatisticTypeName)
)
