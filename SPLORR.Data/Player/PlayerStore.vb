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
    {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
                command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, _playerId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterStore Implements IPlayerStore.Character
        Get
            If HasCharacter Then
                Return New CharacterStore(_connectionSource, _connectionSource.ReadIntegerForInteger(TABLE_PLAYER_CHARACTERS, (FIELD_PLAYER_ID, _playerId), FIELD_CHARACTER_ID))
            End If
            Return Nothing
        End Get
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
End Class
