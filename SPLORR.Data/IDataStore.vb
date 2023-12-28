Public Interface IDataStore
    Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer)
    Function CheckForCharacter(playerId As Integer) As Boolean
    Function GetPlayerForAuthor(authorId As ULong) As Integer
    Sub CleanUp()
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer)
End Interface
