Imports Microsoft.Data.SqlClient

Public Class DataStore
    Implements IDataStore
    Private ReadOnly _connectionString As String
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

    Public Sub LegacyCreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer) Implements IDataStore.LegacyCreatePlayerCharacter
        SetPlayerCharacter(playerId, LegacyCreateCharacter(characterName, locationId, characterType).Id)
    End Sub

    Private Sub SetPlayerCharacter(playerId As Integer, characterId As Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_PLAYER_CHARACTERS}
    (
        {FIELD_PLAYER_ID},
        {FIELD_CHARACTER_ID}
    ) 
    VALUES 
    (
        {PARAMETER_PLAYER_ID},
        {PARAMETER_CHARACTER_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, characterId)
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function LegacyGetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.LegacyGetPlayerForAuthor
        Dim discordId = CLng(authorId)
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
            playerId = LegacyGetPlayerForAuthor(authorId)
        End If
        Return playerId.Value
    End Function

    Public Sub CleanUp() Implements IDataStore.CleanUp
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub

    Public Function LegacyGetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.LegacyGetCharacterTypeGenerator
        Dim result As New Dictionary(Of Integer, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_CHARACTER_TYPE_ID}, 
    {FIELD_GENERATOR_WEIGHT} 
FROM 
    {TABLE_PLAYER_CHARACTER_TYPES};"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(reader.GetInt32(0)) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function LegacyGetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.LegacyGetLocationGenerator
        Dim result As New Dictionary(Of Integer, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_LOCATION_ID}, 
    {FIELD_GENERATOR_WEIGHT} 
FROM 
    {TABLE_LOCATION_STARTS};"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(reader.GetInt32(0)) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function LegacyGetCharacterForPlayer(playerId As Integer) As Integer Implements IDataStore.LegacyGetCharacterForPlayer
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_CHARACTER_ID} 
FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function

    Public Function LegacyGetCharacterName(characterId As Integer) As String Implements IDataStore.LegacyGetCharacterName
        Using command = GetConnection.CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_CHARACTER_NAME} 
FROM 
    {TABLE_CHARACTERS} 
WHERE 
    {FIELD_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, characterId)
            Return CStr(command.ExecuteScalar)
        End Using
    End Function

    Public Sub LegacySetCharacterName(characterId As Integer, characterName As String) Implements IDataStore.LegacySetCharacterName
        Using command = GetConnection.CreateCommand
            command.CommandText = $"
UPDATE 
    {TABLE_CHARACTERS} 
SET 
    {FIELD_CHARACTER_NAME}={PARAMETER_CHARACTER_NAME} 
WHERE 
    {FIELD_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, characterId)
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, characterName)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function GetPlayer(playerId As Integer) As IPlayerStore Implements IDataStore.GetPlayer
        Return New PlayerStore(AddressOf GetConnection, playerId)
    End Function

    Public Function GetCharacter(characterId As Integer) As ICharacterStore Implements IDataStore.GetCharacter
        Return New CharacterStore(AddressOf GetConnection, characterId)
    End Function

    Public Function LegacyCreateCharacter(characterName As String, locationId As Integer, characterType As Integer) As ICharacterStore Implements IDataStore.LegacyCreateCharacter
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_CHARACTERS}
    (
        {FIELD_CHARACTER_NAME},
        {FIELD_LOCATION_ID},
        {FIELD_CHARACTER_TYPE_ID}
    ) 
    VALUES 
    (
        {PARAMETER_CHARACTER_NAME},
        {PARAMETER_LOCATION_ID},
        {PARAMETER_CHARACTER_TYPE_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, characterName)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, locationId)
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_TYPE_ID, characterType)
            command.ExecuteNonQuery()
        End Using
        Using command = GetConnection().CreateCommand
            command.CommandText = $"SELECT @@IDENTITY;"
            Return GetCharacter(CInt(command.ExecuteScalar))
        End Using
    End Function

    Public Function GetLocation(locationId As Integer) As ILocationStore Implements IDataStore.GetLocation
        Return New LocationStore(AddressOf GetConnection, locationId)
    End Function

    Public Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore Implements IDataStore.GetCharacterType
        Return New CharacterTypeStore(AddressOf GetConnection, characterTypeId)
    End Function
End Class
