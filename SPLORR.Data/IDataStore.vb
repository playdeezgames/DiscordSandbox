Public Interface IDataStore
    Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer)
    Function CheckForCharacter(playerId As Integer) As Boolean
    Function GetPlayerForAuthor(authorId As ULong) As Integer
    Sub CleanUp()
End Interface
