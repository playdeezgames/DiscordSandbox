CREATE VIEW [dbo].[CardDetails]
	AS
SELECT
	c.CardId,
	c.CardTypeId,
	c.CharacterId,
	ct.CardTypeName,
	c.InDiscardPile,
	c.InDrawPile,
	c.InHand,
	c.DrawOrder,
	ch.CharacterName
FROM
	Cards c
	JOIN CardTypes ct ON ct.CardTypeId=c.CardTypeId
	JOIN Characters ch ON c.CharacterId=ch.CharacterId
