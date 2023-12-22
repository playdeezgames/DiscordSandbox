Imports Microsoft.Data.SqlClient

Friend Class DataStore
    Private Const CONNECTION_STRING As String = "CONNECTION_STRING"
    Private connection As SqlConnection = Nothing
    Friend ReadOnly Property Players As PlayerStore
        Get
            Return New PlayerStore(AddressOf GetConnection)
        End Get
    End Property
    Private Function GetConnection() As SqlConnection
        If connection Is Nothing Then
            connection = New SqlConnection(Environment.GetEnvironmentVariable(CONNECTION_STRING))
            connection.Open()
        End If
        Return connection
    End Function
    Friend Sub Close()
        If connection IsNot Nothing Then
            connection.Close()
            connection = Nothing
        End If
    End Sub
End Class
