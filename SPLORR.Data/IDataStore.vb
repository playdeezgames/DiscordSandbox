Public Interface IDataStore
    Sub CreateCharacter(authorId As ULong)
    Function CheckForCharacter(authorId As ULong) As Boolean
    Function GetPlayerForAuthor(authorId As ULong) As Integer
End Interface
