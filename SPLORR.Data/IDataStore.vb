Public Interface IDataStore
    'boilerplate
    Sub CleanUp()
    Function GetPlayer(playerId As Integer) As IPlayerStore
    'PlayerStore
    Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer)
    Function CheckForCharacter(playerId As Integer) As Boolean
    Function GetCharacterForPlayer(playerId As Integer) As Integer
    '???
    Function GetPlayerForAuthor(authorId As ULong) As Integer
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer)
    'CharacterStore
    Function GetCharacterName(characterId As Integer) As String
    Sub SetCharacterName(characterId As Integer, characterName As String)
End Interface
