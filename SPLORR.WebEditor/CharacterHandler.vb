Imports System.Text
Imports SPLORR.Data

Friend Module CharacterHandler
    Friend Sub ShowList(builder As StringBuilder, store As IDataStore)
        builder.Append(HTML_START)
        builder.Append("<h1>Characters</h1>")
        builder.Append("<ul>")
        For Each character In store.Characters.All
            builder.Append($"<li><a href=""/{TOKEN_CHARACTER}/{character.Id}"">{character.Name}</a></li>")
        Next
        builder.Append("</ul>")
        builder.Append($"<p><a href=""/"">Main Menu</a></p>")
        builder.Append(HTML_END)
    End Sub

    Friend Sub Show(builder As StringBuilder, store As IDataStore, tokens() As String)
        Dim characterId As Integer = 0
        If tokens.Length = 0 OrElse
            Not Integer.TryParse(tokens.First, characterId) Then
            ShowList(builder, store)
            Return
        End If
        Dim character = store.GetCharacter(characterId)
        If character Is Nothing Then
            ShowList(builder, store)
            Return
        End If
        builder.Append(HTML_START)
        builder.Append($"<p>Id: {character.Id}</p>")
        builder.Append($"<p>Name: {character.Name}</p>")
        builder.Append($"<p><a href=""/{TOKEN_CHARACTERS}"">Characters</a></p>")
        builder.Append(HTML_END)
    End Sub
End Module
