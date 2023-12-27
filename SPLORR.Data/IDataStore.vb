Public Interface IDataStore
    Sub CreateCharacter(playerId As Integer)
    Function CheckForCharacter(playerId As Integer) As Boolean
    Function GetPlayerForAuthor(authorId As ULong) As Integer
    Sub CleanUp()
End Interface
