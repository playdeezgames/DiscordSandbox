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
    Friend Function Handle(player As IPlayerModel, tokens() As String) As String
        If tokens.Length = 0 Then
            Dim builder As New StringBuilder
            builder.AppendLine($"Commands:")
            For Each help In helps
                builder.AppendLine($"- {help.Key}: {help.Value}")
            Next
            Return builder.ToString
        End If
        Return InvalidMessage.Handle(player, tokens)
    End Function
End Module
