Imports Microsoft.Data.SqlClient

Friend Class DataStore
    Implements IDataStore
    Private Const CONNECTION_STRING As String = "CONNECTION_STRING"
    Private connection As SqlConnection = Nothing

    Public ReadOnly Property Players As PlayerStore Implements IDataStore.Players
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
    Public Sub Close() Implements IDataStore.Close
        If connection IsNot Nothing Then
            connection.Close()
            connection = Nothing
        End If
    End Sub
End Class
