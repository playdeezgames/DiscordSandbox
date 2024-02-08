CREATE TABLE [dbo].[EffectTypeLocations]
(
	[EffectTypeLocationId] INT NOT NULL IDENTITY(1,1),
	EffectTypeId INT NOT NULL,
	LocationId INT NOT NULL,
	CONSTRAINT PK_EffectTypeLocations PRIMARY KEY(EffectTypeLocationId),
	CONSTRAINT FK_EffectTypeLocations_EffectTypes FOREIGN KEY(EffectTypeId) REFERENCES EffectTypes(EffectTypeId),
	CONSTRAINT FK_EffectTypeLocations_Locations FOREIGN KEY(LocationId) REFERENCES Locations(LocationId)
)
