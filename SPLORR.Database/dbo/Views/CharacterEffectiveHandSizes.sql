CREATE VIEW [dbo].[CharacterEffectiveHandSizes]
	AS
SELECT
	ch.CharacterId,
	SUM(CAST(ct.HandSize AS INT)) HandSize
FROM
	Characters ch
	LEFT JOIN Cards c ON c.CharacterId=ch.CharacterId AND c.InHand=1
	LEFT JOIN CardTypes ct ON ct.CardTypeId=c.CardTypeId
GROUP BY
	ch.CharacterId