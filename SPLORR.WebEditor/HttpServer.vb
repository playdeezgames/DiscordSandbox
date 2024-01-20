Imports System.IO
Imports System.Net
Imports System.Text
Imports SPLORR.Data

Friend Module HttpServer
    Private Const HTML_START As String = "<html><head><title>SPLORR!!</title></head><body>"
    Private Const HTML_END As String = "</body></html>"
    Private listener As HttpListener
    Private store As IDataStore
    Friend Sub Start(address As String, port As Integer, dataStore As IDataStore)
        store = dataStore
        listener = New HttpListener
        listener.Prefixes.Add($"http://{address}:{port}/")
        listener.Start()
        Receive()
    End Sub
    Friend Sub [Stop]()
        listener.Stop()
    End Sub
    Private Sub Receive()
        listener.BeginGetContext(New AsyncCallback(AddressOf ListenerCallback), listener)
    End Sub

    Private Sub ListenerCallback(ar As IAsyncResult)
        Try
            If listener.IsListening Then
                Dim context = listener.EndGetContext(ar)
                Dim request = context.Request
                HandleRequest(request, context.Response)
                Console.WriteLine($"{request.Url}")
                Receive()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub HandleRequest(
                             request As HttpListenerRequest,
                             response As HttpListenerResponse)
        response.StatusCode = HttpStatusCode.OK
        response.ContentType = "text/html"
        Dim builder As New StringBuilder
        Dim tokens = request.RawUrl.Split("/"c, StringSplitOptions.RemoveEmptyEntries)
        Dim firstToken = If(tokens.Length > 0, tokens(0), String.Empty)
        tokens = If(tokens.Length > 0, tokens.Skip(1).ToArray, tokens)
        Select Case firstToken.ToLower
            Case "characters"
                HandleCharactersRequest(builder, tokens)
            Case Else
                HandleDefaultRequest(builder, tokens)
        End Select
        Using writer As New StreamWriter(response.OutputStream, request.ContentEncoding)
            writer.Write(builder.ToString)
        End Using
        response.OutputStream.Close()
    End Sub

    Private Sub HandleCharactersRequest(builder As StringBuilder, tokens() As String)
        builder.Append(HTML_START)
        builder.Append("<h1>Characters</h1>")
        builder.Append("<ul>")
        For Each character In store.Characters.All
            builder.Append($"<li><a href=""/character/{character.Id}"">{character.Name}</a></li>")
        Next
        builder.Append("</ul>")
        builder.Append("<p><a href=""/"">Main Menu</a></p>")
        builder.Append(HTML_END)
    End Sub

    Private Sub HandleDefaultRequest(builder As StringBuilder, tokens As IEnumerable(Of String))
        builder.Append(HTML_START)
        builder.Append("<h1>Main Menu</h1>")
        builder.Append("<ul>")
        builder.Append("<li><a href=""/characters"">Characters</a></li>")
        builder.Append("</ul>")
        builder.Append(HTML_END)
    End Sub
End Module
