CREATE TABLE [dbo].[Players] (
    [PlayerId]  INT    IDENTITY (1, 1) NOT NULL,
    [DiscordId] BIGINT NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED ([PlayerId] ASC),
    CONSTRAINT [AK_Players_DiscordId] UNIQUE NONCLUSTERED ([DiscordId] ASC)
);

