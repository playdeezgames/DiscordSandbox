CREATE TABLE [dbo].[CardTypes]
(
	[CardTypeId] INT NOT NULL IDENTITY(1,1),
	[CardTypeName] NVARCHAR(100) NOT NULL,
	[DeleteOnPlay] BIT NOT NULL CONSTRAINT DF_CardTypes_DeleteOnPlay DEFAULT(0), 
    [CardTypeGeneratorId] INT NULL, 
    CONSTRAINT PK_CardTypes PRIMARY KEY (CardTypeId),
	CONSTRAINT AK_CardTypes_CardTypeName UNIQUE(CardTypeName),
	CONSTRAINT FK_CardTypes_CardTypeGenerators FOREIGN KEY (CardTypeGeneratorId) REFERENCES CardTypeGenerators(CardTypeGeneratorId)
);
