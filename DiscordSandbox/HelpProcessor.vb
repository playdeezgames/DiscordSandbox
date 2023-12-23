Friend Module HelpProcessor
    Private ReadOnly helps As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {HELP_TOKEN, "If you need help with help, then I can't help you."},
            {PAY_TOKEN, "You get yer current pay."},
            {STATUS_TOKEN, "Tells you yer status!"}
        }
    Friend Function Process(dataStore As IDataStore, playerId As Integer, tokens() As String) As String
        If tokens.Length = 0 Then
            Return $"Commands: 
- {HELP_TOKEN}
- {PAY_TOKEN}
- {STATUS_TOKEN}"
        Else
            Dim topic = tokens.First
            Dim helpText As String = String.Empty
            If helps.TryGetValue(topic, helpText) Then
                Return helps(topic)
            Else
                Return "Invalid help topic!"
            End If
        End If
    End Function
End Module
