CREATE VIEW [dbo].[CharacterTypeAvailableCards]
	AS
SELECT
	cht.CharacterTypeId,
	cat.CardTypeId,
	cat.CardTypeName
FROM
	CharacterTypes cht
	CROSS JOIN CardTypes cat
	LEFT JOIN CharacterTypeCards ctc ON ctc.CharacterTypeId=cht.CharacterTypeId AND ctc.CardTypeId=cat.CardTypeId
WHERE
	ctc.CharacterTypeCardId IS NULL
