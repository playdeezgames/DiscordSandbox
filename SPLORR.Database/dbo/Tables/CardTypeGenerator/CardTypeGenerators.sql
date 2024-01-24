CREATE TABLE [dbo].[CardTypeGenerators]
(
	[CardTypeGeneratorId] INT NOT NULL IDENTITY(1,1),
	[CardTypeGeneratorName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_CardTypeGenerators PRIMARY KEY(CardTypeGeneratorId),
	CONSTRAINT AK_CardTypeGenerators_CardTypeGeneratorName UNIQUE(CardTypeGeneratorName)
)
