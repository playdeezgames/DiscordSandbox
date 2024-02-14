CREATE TABLE [dbo].[CardTypes]
(
	[CardTypeId] INT NOT NULL IDENTITY(1,1),
	[CardTypeName] NVARCHAR(100) NOT NULL
    CONSTRAINT PK_CardTypes PRIMARY KEY (CardTypeId),
	[SelfDestruct] BIT NOT NULL CONSTRAINT DF_CardTypes_SelfDestruct DEFAULT 0, 
    [CardLimit] INT NULL, 
    [AlwaysAvailable] BIT NOT NULL CONSTRAINT DF_CardTypes_AlwaysAvailable DEFAULT 0, 
    CONSTRAINT AK_CardTypes_CardTypeName UNIQUE(CardTypeName),
	CONSTRAINT CK_CardTypes_CardLimit CHECK(CardLimit IS NULL OR CardLimit>0)
);
