CREATE TABLE [dbo].[Routes]
(
	[RouteId] INT NOT NULL IDENTITY(1,1),
	[FromLocationId] INT NOT NULL,
	[ToLocationId] INT NOT NULL,
	[DirectionId] INT NOT NULL,
	[RouteTypeId] INT NOT NULL,
	CONSTRAINT [PK_Routes] PRIMARY KEY ([RouteId]),
	CONSTRAINT [FK_Routes_Locations_FromLocationId] FOREIGN KEY ([FromLocationId]) REFERENCES Locations(LocationId),
	CONSTRAINT [FK_Routes_Locations_ToLocationId] FOREIGN KEY ([ToLocationId]) REFERENCES Locations(LocationId),
	CONSTRAINT [FK_Routes_Directions] FOREIGN KEY ([DirectionId]) REFERENCES Directions(DirectionId)
)
