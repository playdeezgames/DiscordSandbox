Public Interface IBot
    Sub Start()
    Sub [Stop]()
    Function HandleMessage(authorId As ULong, message As String) As String
End Interface
