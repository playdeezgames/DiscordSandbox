CREATE VIEW [dbo].[CharacterTypeCardDetails]
	AS
SELECT
	ctc.CharacterTypeCardId,
	ctc.CharacterTypeId,
	ct.CardTypeId,
	ct.CardTypeName
FROM
	CharacterTypeCards ctc
	JOIN CardTypes ct on ctc.CardTypeId=ct.CardTypeId

