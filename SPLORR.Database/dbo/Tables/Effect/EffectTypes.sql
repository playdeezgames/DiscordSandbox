CREATE TABLE [dbo].[EffectTypes]
(
	[EffectTypeId] INT NOT NULL IDENTITY(1,1),
	[EffectTypeName] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_EffectTypes PRIMARY KEY(EffectTypeId),
	CONSTRAINT AK_EffectTypes_EffectTypeName UNIQUE(EffectTypeName)
)
