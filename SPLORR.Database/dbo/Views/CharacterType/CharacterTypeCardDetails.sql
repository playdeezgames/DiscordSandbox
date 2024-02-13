CREATE VIEW [dbo].[CharacterTypeCardDetails]
	AS
SELECT
	ctc.CharacterTypeCardId,
	ctc.CharacterTypeId,
	ctc.CardQuantity,
	ctc.CardTypeId,
	ct.CardTypeName,
	cht.CharacterTypeName
FROM
	CharacterTypeCards ctc
	JOIN CardTypes ct on ctc.CardTypeId=ct.CardTypeId
	JOIN CharacterTypes cht ON ctc.CharacterTypeId = cht.CharacterTypeId

