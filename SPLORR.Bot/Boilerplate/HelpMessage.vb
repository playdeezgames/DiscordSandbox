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
    Private ReadOnly helpTopics As IReadOnlyDictionary(Of String, action(Of IPlayerModel, String(), Action(Of String))) =
        New Dictionary(Of String, Action(Of IPlayerModel, String(), Action(Of  String))) From
        {
            {TOKEN_CREATE, AddressOf HelpCreate},
            {TOKEN_GO, AddressOf HelpGo},
            {TOKEN_HELP, AddressOf HelpHelp},
            {TOKEN_STATUS, AddressOf HelpStatus}
        }

    Private Sub HelpStatus(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_STATUS}:")
        outputter($"- usage: {TOKEN_STATUS}")
    End Sub

    Private Sub HelpHelp(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_HELP}:")
        outputter($"- usage: {TOKEN_HELP} <topic>")
    End Sub

    Private sub HelpGo(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_GO}:")
        outputter($"- usage: {TOKEN_GO} <direction>")
    End sub

    Private sub HelpCreate(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_CREATE}:")
        outputter($"- usage: {TOKEN_CREATE} <thing>")
        outputter($"- values for <thing>: {TOKEN_CHARACTER}")
    End sub

    Friend sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length = 0 Then
            outputter($"Commands:")
            For Each help In helps
                outputter($"- {help.Key}: {help.Value}")
            Next
            Return
        End If
        Dim firstToken = tokens.First.ToLower
        tokens = tokens.Skip(1).ToArray
        Dim handler As Action(Of IPlayerModel, String(), Action(Of String)) = Nothing
        If helpTopics.TryGetValue(firstToken, handler) Then
            handler(player, tokens, outputter)
            Return
        End If
        InvalidMessage.Handle(player, tokens, outputter)
    End sub
End Module
