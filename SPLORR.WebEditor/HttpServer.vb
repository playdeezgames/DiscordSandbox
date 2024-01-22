Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports SPLORR.Data

Friend Module HttpServer
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
        Dim tokens = request.RawUrl.Split(SLASH, StringSplitOptions.RemoveEmptyEntries)
        Dim firstToken = If(tokens.Length > 0, tokens(0), String.Empty)
        tokens = If(tokens.Length > 0, tokens.Skip(1).ToArray, tokens)
        Select Case firstToken.ToLower
            Case TOKEN_CHARACTERS
                CharacterHandler.ShowList(builder, store)
            Case TOKEN_CHARACTER
                CharacterHandler.Show(builder, store, tokens)
            Case TOKEN_CHARACTER_TYPES
                CharacterTypeHandler.ShowList(builder, store)
            Case TOKEN_CHARACTER_TYPE
                CharacterTypeHandler.Show(builder, store, tokens)
            Case Else
                DefaultHandler.Show(builder)
        End Select
        Using writer As New StreamWriter(response.OutputStream, request.ContentEncoding)
            writer.Write(builder.ToString)
        End Using
        response.OutputStream.Close()
    End Sub
End Module
