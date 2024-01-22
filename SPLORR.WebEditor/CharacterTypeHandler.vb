Imports System.Text
Imports SPLORR.Data

Friend Module CharacterTypeHandler
    Friend Sub ShowList(builder As Text.StringBuilder, store As Data.IDataStore)
        builder.Append(HTML_START)
        builder.Append("<h1>Character Types</h1>")
        builder.Append("<ul>")
        For Each characterType In store.CharacterTypes.All
            builder.Append($"<li><a href=""/{TOKEN_CHARACTER_TYPE}/{characterType.Id}"">{characterType.Name}</a></li>")
        Next
        builder.Append("</ul>")
        builder.Append($"<p><a href=""/"">Main Menu</a></p>")
        builder.Append(HTML_END)
    End Sub

    Friend Sub Show(builder As StringBuilder, store As IDataStore, tokens() As String)
        Dim characterTypeId As Integer = 0
        If tokens.Length = 0 OrElse
            Not Integer.TryParse(tokens.First, characterTypeId) Then
            ShowList(builder, store)
            Return
        End If
        tokens = tokens.Skip(1).ToArray
        Dim characterType = store.GetCharacterType(characterTypeId)
        If characterType Is Nothing Then
            ShowList(builder, store)
            Return
        End If
        builder.Append(HTML_START)
        builder.Append($"<p>Id: {characterType.Id}</p>")
        builder.Append($"<p>Name: {characterType.Name} (<a href=""/{TOKEN_CHARACTER_TYPE}/{characterTypeId}/{TOKEN_CHANGE_NAME}"">(change)</a>)</p>")
        builder.Append($"<p><a href=""/{TOKEN_CHARACTER_TYPES}"">Character Types</a></p>")
        builder.Append(HTML_END)
    End Sub
End Module
