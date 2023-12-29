Imports Microsoft.Data.SqlClient

Public Class DataStore
    Implements IDataStore
    Private ReadOnly _connectionString As String = Nothing
    Private _connection As SqlConnection = Nothing
    Private Function GetConnection() As SqlConnection
        If _connection Is Nothing Then
            _connection = New SqlConnection(_connectionString)
            _connection.Open()
        End If
        Return _connection
    End Function
    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub
    Friend Sub New(connection As SqlConnection)
        _connection = connection
    End Sub

    Public Sub LegacyCreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer) Implements IDataStore.LegacyCreatePlayerCharacter
        Dim character As ICharacterStore
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
            character = GetCharacter(CInt(command.ExecuteScalar))
        End Using
        SetPlayerCharacter(playerId, character.Id)
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

    Public Function GetPlayer(playerId As Integer) As IPlayerStore Implements IDataStore.GetPlayer
        Return New PlayerStore(AddressOf GetConnection, playerId)
    End Function

    Public Function GetCharacter(characterId As Integer) As ICharacterStore Implements IDataStore.GetCharacter
        Return New CharacterStore(AddressOf GetConnection, characterId)
    End Function

    Public Function GetLocation(locationId As Integer) As ILocationStore Implements IDataStore.GetLocation
        Return New LocationStore(AddressOf GetConnection, locationId)
    End Function

    Public Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore Implements IDataStore.GetCharacterType
        Return New CharacterTypeStore(AddressOf GetConnection, characterTypeId)
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer) Implements IDataStore.GetCharacterTypeGenerator
        Dim result As New Dictionary(Of ICharacterTypeStore, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_CHARACTER_TYPE_ID}, 
    {FIELD_GENERATOR_WEIGHT} 
FROM 
    {TABLE_PLAYER_CHARACTER_TYPES};"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(GetCharacterType(reader.GetInt32(0))) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer) Implements IDataStore.GetLocationGenerator
        Dim result As New Dictionary(Of ILocationStore, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_LOCATION_ID}, 
    {FIELD_GENERATOR_WEIGHT} 
FROM 
    {TABLE_LOCATION_STARTS};"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(GetLocation(reader.GetInt32(0))) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore Implements IDataStore.CreateCharacter
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
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, location.Id)
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_TYPE_ID, characterType.Id)
            command.ExecuteNonQuery()
        End Using
        Using command = GetConnection().CreateCommand
            command.CommandText = $"SELECT @@IDENTITY;"
            Return GetCharacter(CInt(command.ExecuteScalar))
        End Using
    End Function
End Class
