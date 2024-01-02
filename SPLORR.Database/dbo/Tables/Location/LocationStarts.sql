CREATE TABLE [dbo].[LocationStarts] (
    [LocationId]      INT NOT NULL,
    [GeneratorWeight] INT NOT NULL,
    CONSTRAINT [PK_LocationStarts] PRIMARY KEY CLUSTERED ([LocationId] ASC),
    CONSTRAINT [FK_LocationStarts_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([LocationId])
);

