CREATE TABLE [dbo].[LocationTypeVerbTypes]
(
	[LocationTypeVerbTypeId] INT NOT NULL IDENTITY(1,1),
	[LocationTypeId] INT NOT NULL,
	[VerbTypeId] INT NOT NULL,
	CONSTRAINT PK_LocationTypeVerbTypes PRIMARY KEY([LocationTypeVerbTypeId]),
	CONSTRAINT FK_LocationTypeVerbTypes_LocationTypes FOREIGN KEY ([LocationTypeId]) REFERENCES LocationTypes(LocationTypeId),
	CONSTRAINT FK_LocationTypeVerbTypes_VerbTypes FOREIGN KEY ([VerbTypeId]) REFERENCES VerbTypes(VerbTypeId),
	CONSTRAINT AK_LocationType_VerbTypes_LocationTypeId_VerbTypeId UNIQUE(LocationTypeId, VerbTypeId)
)
