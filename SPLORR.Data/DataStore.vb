Imports Microsoft.Data.SqlClient

Public Class DataStore
    Implements IDataStore
    Private _connectionString As String
    Private _connection As SqlConnection = Nothing
    Private Function GetConnection() As SqlConnection
        If _connection Is Nothing Then
            _connection = New SqlConnection(_connectionString)
            _connection.Open()
        End If
        Return _connection
    End Function
    Public Sub New(connectionString As String)
        Me._connectionString = connectionString
    End Sub

    Public Sub CreateCharacter(playerId As Integer) Implements IDataStore.CreateCharacter
        Throw New NotImplementedException()
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        Throw New NotImplementedException()
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        Throw New NotImplementedException()
    End Function

    Public Sub CleanUp() Implements IDataStore.CleanUp
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub
End Class
