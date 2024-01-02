Imports Microsoft.Data.SqlClient

Friend Class PlayerStore
    Implements IPlayerStore
    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _playerId As Integer
    Sub New(connectionSource As Func(Of SqlConnection), playerId As Integer)
        _connectionSource = connectionSource
        _playerId = playerId
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerStore.HasCharacter
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {COLUMN_PLAYER_ID}={PARAMETER_PLAYER_ID};"
                command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, _playerId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public Property Character As ICharacterStore Implements IPlayerStore.Character
        Get
            If HasCharacter Then
                Return New CharacterStore(_connectionSource, _connectionSource.ReadIntegerForInteger(TABLE_PLAYER_CHARACTERS, (COLUMN_PLAYER_ID, _playerId), COLUMN_CHARACTER_ID))
            End If
            Return Nothing
        End Get
        Set(value As ICharacterStore)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
DELETE FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {COLUMN_PLAYER_ID}={PARAMETER_PLAYER_ID};"
                command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, _playerId)
                command.ExecuteNonQuery()
            End Using
            Using command = _connectionSource().CreateCommand
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
                command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, _playerId)
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, value.Id)
                command.ExecuteNonQuery()
            End Using
        End Set
    End Property

    Private ReadOnly Property Store As IDataStore
        Get
            Return New DataStore(_connectionSource())
        End Get
    End Property

    Public Function CreateCharacter(
                                   characterName As String,
                                   location As ILocationStore,
                                   characterType As ICharacterTypeStore
                                   ) As ICharacterStore Implements IPlayerStore.CreateCharacter
        Return Store.CreateCharacter(characterName, location, characterType)
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer) Implements IPlayerStore.GetCharacterTypeGenerator
        Return Store.GetCharacterTypeGenerator
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer) Implements IPlayerStore.GetLocationGenerator
        Return Store.GetLocationGenerator
    End Function

    Public Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeStore Implements IPlayerStore.GetVerbTypeByName
        Return Store.GetVerbTypeByName(verbTypeName)
    End Function
End Class
