Imports SPLORR.Model

Friend Module Message
    Private ReadOnly handlers As IReadOnlyDictionary(Of String, Action(Of IPlayerModel, String(), Action(Of String))) =
        New Dictionary(Of String, Action(Of IPlayerModel, String(), Action(Of String))) From
        {
            {TOKEN_CARDS, AddressOf CardsMessage.Handle},
            {TOKEN_CHARACTER, AddressOf CharacterMessage.Handle},
            {TOKEN_CREATE, AddressOf CreateMessage.Handle},
            {TOKEN_DESCRIBE, AddressOf DescribeMessage.Handle},
            {TOKEN_DIE, AddressOf DieMessage.Handle},
            {TOKEN_HAND, AddressOf HandMessage.Handle},
            {TOKEN_HELP, AddressOf HelpMessage.Handle},
            {TOKEN_PLAY, AddressOf PlayMessage.Handle},
            {TOKEN_RENAME, AddressOf RenameMessage.Handle},
            {TOKEN_STATUS, AddressOf StatusMessage.Handle}
        }
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        Dim firstToken = tokens.First
        Dim handler As Action(Of IPlayerModel, String(), Action(Of String)) = Nothing
        If handlers.TryGetValue(firstToken, handler) Then
            handler(player, tokens.Skip(1).ToArray, outputter)
            Return
        End If
        InvalidMessage.Handle(player, tokens, outputter)
    End Sub
End Module
