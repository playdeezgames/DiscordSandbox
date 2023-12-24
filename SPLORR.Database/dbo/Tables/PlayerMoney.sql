CREATE TABLE [dbo].[PlayerMoney] (
    [PlayerId]   INT                NOT NULL,
    [PaymentDue] DATETIMEOFFSET (7) NOT NULL,
    [Amount]     INT                NOT NULL,
    CONSTRAINT [PK_PlayerMoney] PRIMARY KEY CLUSTERED ([PlayerId] ASC),
    CONSTRAINT [FK_PlayerMoney_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([PlayerId])
);

