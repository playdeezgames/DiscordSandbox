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
    Private ReadOnly Property ConnectionSource As Func(Of SqlConnection)
        Get
            Return AddressOf GetConnection
        End Get
    End Property

    Public ReadOnly Property VerbTypes As ITypeStore(Of IVerbTypeStore) Implements IDataStore.VerbTypes
        Get
            Return New TypeStore(Of IVerbTypeStore)(
                ConnectionSource,
                TABLE_VERB_TYPES,
                COLUMN_VERB_TYPE_ID,
                COLUMN_VERB_TYPE_NAME,
                Function(x, y) New VerbTypeStore(x, y))
        End Get
    End Property

    Private Sub SetPlayerCharacter(playerId As Integer, characterId As Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_PLAYER_CHARACTERS}
    (
        {COLUMN_PLAYER_ID},
        {COLUMN_CHARACTER_ID}
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

    Public Sub CleanUp() Implements IDataStore.CleanUp
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub

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
    {COLUMN_CHARACTER_TYPE_ID}, 
    {COLUMN_GENERATOR_WEIGHT} 
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
    {COLUMN_LOCATION_ID}, 
    {COLUMN_GENERATOR_WEIGHT} 
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
        {COLUMN_CHARACTER_NAME},
        {COLUMN_LOCATION_ID},
        {COLUMN_CHARACTER_TYPE_ID}
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
        Return GetCharacter(ConnectionSource.GetLastIdentity())
    End Function

    Private Function FindAuthorPlayer(authorId As ULong) As Integer?
        Dim discordId = CLng(authorId)
        Using command = GetConnection().CreateCommand()
            command.CommandText = $"
        SELECT 
            {COLUMN_PLAYER_ID} 
        FROM 
            {TABLE_PLAYERS} 
        WHERE 
            {COLUMN_DISCORD_ID}={PARAMETER_DISCORD_ID};"
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return reader.GetInt32(0)
                End If
            End Using
        End Using
        Return Nothing
    End Function

    Public Function GetAuthorPlayer(authorId As ULong) As IPlayerStore Implements IDataStore.GetAuthorPlayer
        Dim playerId As Integer? = FindAuthorPlayer(authorId)
        If Not playerId.HasValue Then
            Using command = GetConnection().CreateCommand
                command.CommandText = $"
        INSERT INTO 
            {TABLE_PLAYERS}
            (
                {COLUMN_DISCORD_ID}
            ) 
        VALUES
            (
                {PARAMETER_DISCORD_ID}
            );"
                command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, CLng(authorId))
                command.ExecuteNonQuery()
            End Using
            playerId = FindAuthorPlayer(authorId)
        End If
        Return New PlayerStore(AddressOf GetConnection, playerId.Value)
    End Function

    Public Function FilterLocationTypes(filter As String) As IEnumerable(Of ILocationTypeStore) Implements IDataStore.FilterLocationTypes
        Dim result As New List(Of ILocationTypeStore)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_LOCATION_TYPE_ID} 
FROM 
    {TABLE_LOCATION_TYPES} 
WHERE 
    {COLUMN_LOCATION_TYPE_NAME} LIKE {PARAMETER_LOCATION_TYPE_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_NAME, filter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(New LocationTypeStore(AddressOf GetConnection, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function CreateLocationType(locationTypeName As String) As ILocationTypeStore Implements IDataStore.CreateLocationType
        Using command = GetConnection().CreateCommand
            command.CommandText = $"INSERT INTO {TABLE_LOCATION_TYPES}({COLUMN_LOCATION_TYPE_NAME}) VALUES({PARAMETER_LOCATION_TYPE_NAME});"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_NAME, locationTypeName)
            command.ExecuteNonQuery()
        End Using
        Return GetLocationType(ConnectionSource.GetLastIdentity())
    End Function

    Private Function GetLocationType(locationTypeId As Integer) As ILocationTypeStore
        Return New LocationTypeStore(AddressOf GetConnection, locationTypeId)
    End Function


    Private Function GetVerbType(verbTypeId As Integer) As IVerbTypeStore
        Return New VerbTypeStore(AddressOf GetConnection, verbTypeId)
    End Function

    Public Function LocationTypeNameExists(locationTypeName As String) As Boolean Implements IDataStore.LocationTypeNameExists
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_LOCATION_TYPES} 
WHERE 
    {COLUMN_LOCATION_TYPE_NAME}={PARAMETER_LOCATION_TYPE_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_NAME, locationTypeName)
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function

    Public Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeStore Implements IDataStore.GetVerbTypeByName
        Dim verbTypeId = ConnectionSource.FindIntegerForString(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_NAME, verbTypeName), COLUMN_VERB_TYPE_ID)
        If Not verbTypeId.HasValue Then
            Return Nothing
        End If
        Return New VerbTypeStore(ConnectionSource, verbTypeId.Value)
    End Function

    Private Function FilterType(Of TStore)(
                                          tableName As String,
                                          filterColumn As (Name As String, Filter As String),
                                          outputColumnName As String,
                                          convertor As Func(Of SqlDataReader, TStore)) As IEnumerable(Of TStore)
        Dim result As New List(Of TStore)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {outputColumnName} 
FROM 
    {tableName} 
WHERE 
    {filterColumn.Name} LIKE @{filterColumn.Name};"
            command.Parameters.AddWithValue($"@{filterColumn.Name}", filterColumn.Filter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(convertor(reader))
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function FilterItemTypes(filter As String) As IEnumerable(Of IItemTypeStore) Implements IDataStore.FilterItemTypes
        Return FilterType(Of IItemTypeStore)(
            TABLE_ITEM_TYPES,
            (COLUMN_ITEM_TYPE_NAME, filter),
            COLUMN_ITEM_TYPE_ID,
            Function(r) New ItemTypeStore(AddressOf GetConnection, r.GetInt32(0)))
    End Function

    Public Function ItemTypeNameExists(itemTypeName As String) As Boolean Implements IDataStore.ItemTypeNameExists
        Return ConnectionSource.FindIntegerForString(TABLE_ITEM_TYPES, (COLUMN_ITEM_TYPE_NAME, itemTypeName), COLUMN_ITEM_TYPE_ID).HasValue
    End Function

    Public Function CreateItemType(itemTypeName As String) As IItemTypeStore Implements IDataStore.CreateItemType
        Using command = GetConnection().CreateCommand
            command.CommandText = $"INSERT INTO {TABLE_ITEM_TYPES}({COLUMN_ITEM_TYPE_NAME}) VALUES({PARAMETER_ITEM_TYPE_NAME});"
            command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_NAME, itemTypeName)
            command.ExecuteNonQuery()
        End Using
        Return GetItemType(ConnectionSource.GetLastIdentity())
    End Function

    Private Function GetItemType(itemTypeId As Integer) As IItemTypeStore
        Return New ItemTypeStore(ConnectionSource, itemTypeId)
    End Function

    Public Function FilterItemTypeGenerators(filter As String) As IEnumerable(Of IItemTypeGeneratorStore) Implements IDataStore.FilterItemTypeGenerators
        Return FilterType(Of IItemTypeGeneratorStore)(
            TABLE_ITEM_TYPE_GENERATORS,
            (COLUMN_ITEM_TYPE_GENERATOR_NAME, filter),
            COLUMN_ITEM_TYPE_GENERATOR_ID,
            Function(r) New ItemTypeGeneratorStore(AddressOf GetConnection, r.GetInt32(0)))
    End Function

    Public Function ItemTypeGeneratorNameExists(itemTypeGeneratorName As String) As Boolean Implements IDataStore.ItemTypeGeneratorNameExists
        Return ConnectionSource.FindIntegerForString(
            TABLE_ITEM_TYPE_GENERATORS,
            (COLUMN_ITEM_TYPE_GENERATOR_NAME, itemTypeGeneratorName),
            COLUMN_ITEM_TYPE_GENERATOR_ID).HasValue
    End Function

    Public Function CreateItemTypeGenerator(itemTypeGeneratorName As String) As IItemTypeGeneratorStore Implements IDataStore.CreateItemTypeGenerator
        Using command = GetConnection().CreateCommand
            command.CommandText = $"INSERT INTO {TABLE_ITEM_TYPE_GENERATORS}({COLUMN_ITEM_TYPE_GENERATOR_NAME}) VALUES({PARAMETER_ITEM_TYPE_GENERATOR_NAME});"
            command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_GENERATOR_NAME, itemTypeGeneratorName)
            command.ExecuteNonQuery()
        End Using
        Return GetItemTypeGenerator(ConnectionSource.GetLastIdentity())
    End Function

    Private Function GetItemTypeGenerator(itemTypeGeneratorId As Integer) As IItemTypeGeneratorStore
        Return New ItemTypeGeneratorStore(ConnectionSource, itemTypeGeneratorId)
    End Function
End Class
