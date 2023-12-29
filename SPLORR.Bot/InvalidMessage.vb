Imports SPLORR.Model

Friend Module InvalidMessage
    Friend Function Handle(player As IPlayerModel, tokens() As String) As String
        Return MESSAGE_INVALID_INPUT
    End Function
End Module
