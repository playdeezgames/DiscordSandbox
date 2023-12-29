CREATE TABLE [dbo].[Directions]
(
	[DirectionId] INT NOT NULL IDENTITY(1,1),
	[DirectionName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Directions PRIMARY KEY(DirectionId),
	CONSTRAINT AK_Directions_DirectionName UNIQUE(DirectionName)
)
