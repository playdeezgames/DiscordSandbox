CREATE TABLE [dbo].[CardTypeGeneratorCardTypes]
(
	[CardTypeGeneratorCardTypeId] INT NOT NULL IDENTITY(1,1),
	[CardTypeGeneratorId] INT NOT NULL,
	[CardTypeId] INT NOT NULL,
	[GeneratorWeight] INT NOT NULL,
	CONSTRAINT PK_CardTypeGeneratorCardTypes PRIMARY KEY([CardTypeGeneratorCardTypeId]),
	CONSTRAINT AK_CardTypeGeneratorCardTypes_CardTypeGeneratorId_CardTypeId UNIQUE ([CardTypeGeneratorId],[CardTypeId]),
	CONSTRAINT CK_CardTypeGeneratorCardTypes_GeneratorWeight CHECK(GeneratorWeight>0),
	CONSTRAINT FK_CardTypeGeneratorCardTypes_CardTypeGeneratorId FOREIGN KEY(CardTypeGeneratorId) REFERENCES CardTypeGenerators(CardTypeGeneratorId),
	CONSTRAINT FK_CardTypeGeneratorCardTypes_CardTypeId FOREIGN KEY(CardTypeId) REFERENCES CardTypes(CardTypeId)
);
