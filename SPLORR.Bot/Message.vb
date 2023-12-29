Imports SPLORR.Model

Friend Module Message
    Private ReadOnly handlers As IReadOnlyDictionary(Of String, Func(Of IPlayerModel, String(), String)) =
        New Dictionary(Of String, Func(Of IPlayerModel, String(), String)) From
        {
            {TOKEN_CREATE, AddressOf CreateMessage.Handle},
            {TOKEN_STATUS, AddressOf StatusMessage.Handle},
            {TOKEN_RENAME, AddressOf RenameMessage.Handle}
        }
    Friend Function Handle(player As IPlayerModel, tokens() As String) As String
        Dim firstToken = tokens.First
        Dim handler As Func(Of IPlayerModel, String(), String) = Nothing
        If handlers.TryGetValue(firstToken, handler) Then
            Return handler(player, tokens.Skip(1).ToArray)
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Module
