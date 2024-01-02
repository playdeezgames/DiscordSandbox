CREATE TABLE [dbo].[RouteTypes]
(
	[RouteTypeId] INT NOT NULL IDENTITY(1,1),
	[RouteTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_RouteTypes PRIMARY KEY(RouteTypeId),
	CONSTRAINT AK_RouteTypes_RouteTypeName UNIQUE(RouteTypeName)
)
