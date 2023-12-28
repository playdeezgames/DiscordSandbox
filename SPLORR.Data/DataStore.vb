﻿Imports Microsoft.Data.SqlClient

Public Class DataStore
    Implements IDataStore
    Const TABLE_PLAYERS = "Players"
    Const FIELD_PLAYER_ID = "PlayerId"
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

    Public Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer) Implements IDataStore.CreatePlayerCharacter
        Throw New NotImplementedException()
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        Const PARAMETER_PLAYER_ID = "@PlayerId"
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_PLAYERS} 
WHERE 
    {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        Dim discordId = CLng(authorId)
        Const PARAMETER_DISCORD_ID = "@DiscordId"
        Const FIELD_DISCORD_ID = "DiscordId"
        Dim playerId As Integer? = Nothing
        Using command = GetConnection().CreateCommand()
            command.CommandText = $"
SELECT 
    {FIELD_PLAYER_ID} 
FROM 
    {TABLE_PLAYERS} 
WHERE 
    {FIELD_DISCORD_ID}={PARAMETER_DISCORD_ID};"
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    playerId = reader.GetInt32(0)
                End If
            End Using
        End Using
        If Not playerId.HasValue Then
            Using command = GetConnection().CreateCommand
                command.CommandText = $"
INSERT INTO 
    {TABLE_PLAYERS}
    (
        {FIELD_DISCORD_ID}
    ) 
VALUES
    (
        {PARAMETER_DISCORD_ID}
    );"
                command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
                command.ExecuteNonQuery()
            End Using
            playerId = GetPlayerForAuthor(authorId)
        End If
        Return playerId.Value
    End Function

    Public Sub CleanUp() Implements IDataStore.CleanUp
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetCharacterTypeGenerator
        Throw New NotImplementedException()
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetLocationGenerator
        Throw New NotImplementedException()
    End Function
End Class
