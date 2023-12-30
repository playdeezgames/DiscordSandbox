Imports SPLORR.Model

Friend Module InvalidMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        outputter(MESSAGE_INVALID_INPUT)
    End Sub
End Module
