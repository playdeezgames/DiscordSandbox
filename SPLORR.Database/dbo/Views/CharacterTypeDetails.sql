CREATE VIEW [dbo].[CharacterTypeDetails]
	AS
SELECT
	ct.CharacterTypeId,
	ct.CharacterTypeName
FROM
	CharacterTypes ct
