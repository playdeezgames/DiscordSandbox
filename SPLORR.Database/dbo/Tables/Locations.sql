CREATE TABLE [dbo].[Locations] (
    [LocationId]   INT            IDENTITY (1, 1) NOT NULL,
    [LocationName] NVARCHAR (100) NOT NULL,
    [LocationType] INT            NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([LocationId] ASC)
);

