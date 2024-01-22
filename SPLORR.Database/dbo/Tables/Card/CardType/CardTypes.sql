CREATE TABLE [dbo].[CardTypes]
(
	[CardTypeId] INT NOT NULL IDENTITY(1,1),
	[CardTypeName] NVARCHAR(100) NOT NULL,
	[DeleteOnPlay] BIT NOT NULL, 
    CONSTRAINT PK_CardTypes PRIMARY KEY (CardTypeId),
	CONSTRAINT AK_CardTypes_CardTypeName UNIQUE(CardTypeName)
);
