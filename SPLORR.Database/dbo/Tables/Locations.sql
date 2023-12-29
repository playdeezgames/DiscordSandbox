CREATE TABLE [dbo].[Locations] (
    [LocationId]   INT            IDENTITY (1, 1) NOT NULL,
    [LocationName] NVARCHAR (100) NOT NULL,
    [LocationTypeId] INT            NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([LocationId] ASC),
    CONSTRAINT [FK_Locations_LocationTypes] FOREIGN KEY (LocationTypeId) REFERENCES LocationTypes(LocationTypeId)
);

