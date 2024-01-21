CREATE TABLE [dbo].[CardTypeTags]
(
	[CardTypeTagId] INT NOT NULL IDENTITY(1,1),
	[CardTypeId] INT NOT NULL,
	[TagName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_CardTypeTags PRIMARY KEY(CardTypeTagId),
	CONSTRAINT AK_CardTypeTags_CardTypeId_TagName UNIQUE(CardTypeId,TagName),
	CONSTRAINT FK_CardTypeTags_CardTypes FOREIGN KEY (CardTypeId) REFERENCES CardTypes(CardTypeId)
)
