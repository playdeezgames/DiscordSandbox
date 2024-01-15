CREATE VIEW [dbo].[CardDetails]
	AS
SELECT
	c.CardId,
	c.CardTypeId,
	c.CharacterId,
	ct.CardTypeName
FROM
	Cards c
	JOIN CardTypes ct ON ct.CardTypeId=c.CardTypeId
