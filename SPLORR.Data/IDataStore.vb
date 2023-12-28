Public Interface IDataStore
    Sub CleanUp()
    Function GetPlayer(playerId As Integer) As IPlayerStore
    Function GetCharacter(characterId As Integer) As ICharacterStore
    Function GetLocation(locationId As Integer) As ILocationStore
    Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore
    Function LegacyCreateCharacter(characterName As String, locationId As Integer, characterType As Integer) As ICharacterStore
    'PlayerStore
    Sub LegacyCreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer)
    Function LegacyGetCharacterForPlayer(playerId As Integer) As Integer
    '???
    Function LegacyGetPlayerForAuthor(authorId As ULong) As Integer
    Function LegacyGetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer)
    Function LegacyGetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer)
    'CharacterStore
    Function LegacyGetCharacterName(characterId As Integer) As String
    Sub LegacySetCharacterName(characterId As Integer, characterName As String)
End Interface
