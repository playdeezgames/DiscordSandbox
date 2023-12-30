Imports System.Text
Imports SPLORR.Model

Friend Module HelpMessage
    Private ReadOnly helps As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {TOKEN_CREATE, "Allows you to create stuff."},
            {TOKEN_GO, "Allows you to move yer character in a direction."},
            {TOKEN_HELP, "Shows help."},
            {TOKEN_STATUS, "Shows yer status."}
        }
    Private ReadOnly helpTopics As IReadOnlyDictionary(Of String, Func(Of IPlayerModel, String(), String)) =
        New Dictionary(Of String, Func(Of IPlayerModel, String(), String)) From
        {
            {TOKEN_CREATE, AddressOf HelpCreate},
            {TOKEN_GO, AddressOf HelpGo},
            {TOKEN_HELP, AddressOf HelpHelp},
            {TOKEN_STATUS, AddressOf HelpStatus}
        }

    Private Function HelpStatus(player As IPlayerModel, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidMessage.Handle(player, tokens)
        End If
        Return $"Help for {TOKEN_STATUS}:
- usage: {TOKEN_STATUS}"
    End Function

    Private Function HelpHelp(player As IPlayerModel, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidMessage.Handle(player, tokens)
        End If
        Return $"Help for {TOKEN_HELP}:
- usage: {TOKEN_HELP} <topic>"
    End Function

    Private Function HelpGo(player As IPlayerModel, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidMessage.Handle(player, tokens)
        End If
        Return $"Help for {TOKEN_GO}:
- usage: {TOKEN_GO} <direction>"
    End Function

    Private Function HelpCreate(player As IPlayerModel, tokens() As String) As String
        If tokens.Length <> 0 Then
            Return InvalidMessage.Handle(player, tokens)
        End If
        Return $"Help for {TOKEN_CREATE}:
- usage: {TOKEN_CREATE} <thing>
- values for <thing>: {TOKEN_CHARACTER}"
    End Function

    Friend Function Handle(player As IPlayerModel, tokens() As String) As String
        If tokens.Length = 0 Then
            Dim builder As New StringBuilder
            builder.AppendLine($"Commands:")
            For Each help In helps
                builder.AppendLine($"- {help.Key}: {help.Value}")
            Next
            Return builder.ToString
        End If
        Dim firstToken = tokens.First.ToLower
        tokens = tokens.Skip(1).ToArray
        Dim handler As Func(Of IPlayerModel, String(), String) = Nothing
        If helpTopics.TryGetValue(firstToken, handler) Then
            Return handler(player, tokens)
        End If
        Return InvalidMessage.Handle(player, tokens)
    End Function
End Module
