Public Interface IDataStore
    Sub CreateCharacter(authorId As ULong)
    Function CheckForCharacter(authorId As ULong) As Boolean
End Interface
