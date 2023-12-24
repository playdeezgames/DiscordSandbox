Public Interface IBot
    Sub Start()
    Sub [Stop]()
    Function HandleMessage() As String
End Interface
