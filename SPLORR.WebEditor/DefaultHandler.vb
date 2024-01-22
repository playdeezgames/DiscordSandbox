Imports System.Text

Friend Module DefaultHandler
    Friend Sub Show(builder As StringBuilder)
        builder.Append(HTML_START)
        builder.Append("<h1>Main Menu</h1>")
        builder.Append("<ul>")
        builder.Append($"<li><a href=""/{TOKEN_CHARACTER_TYPES}"">Character Types</a></li>")
        builder.Append($"<li><a href=""/{TOKEN_CHARACTERS}"">Characters</a></li>")
        builder.Append("</ul>")
        builder.Append(HTML_END)
    End Sub
End Module
