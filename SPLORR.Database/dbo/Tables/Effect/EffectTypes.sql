CREATE TABLE [dbo].[EffectTypes]
(
	[EffectTypeId] INT NOT NULL IDENTITY(1,1),
	[EffectTypeName] NVARCHAR(100) NOT NULL,
	[LocationTypeId] INT NULL, 
	[DiscardHand] BIT NOT NULL CONSTRAINT DF_EffectTypes_DiscardHand DEFAULT 0, 
    --when not set, any location type is allowed. when set, only this location type is allowed
    CONSTRAINT PK_EffectTypes PRIMARY KEY(EffectTypeId),
	CONSTRAINT AK_EffectTypes_EffectTypeName UNIQUE(EffectTypeName),
	CONSTRAINT FK_EffectTypes_LocationTypes FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
)
