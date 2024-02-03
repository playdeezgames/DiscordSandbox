CREATE VIEW [dbo].[CharacterTypeDetails]
	AS
SELECT
	ct.CharacterTypeId,
	ct.CharacterTypeName,
	ct.IsPlayerSelectable,
	ct.GeneratorWeight
FROM
	CharacterTypes ct
