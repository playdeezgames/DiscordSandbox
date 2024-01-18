Imports Microsoft.Data.SqlClient

Friend Class PlayerStore
    Implements IPlayerStore
    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly _playerId As Integer
    Sub New(connectionSource As Func(Of SqlConnection), playerId As Integer)
        Me.connectionSource = connectionSource
        _playerId = playerId
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerStore.HasCharacter
        Get
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {COLUMN_PLAYER_ID}=@{COLUMN_PLAYER_ID};"
                command.Parameters.AddWithValue($"@{COLUMN_PLAYER_ID}", _playerId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public Property Character As ICharacterStore Implements IPlayerStore.Character
        Get
            If HasCharacter Then
                Return New CharacterStore(
                    connectionSource,
                    connectionSource.ReadIntegerForValues(
                        TABLE_PLAYER_CHARACTERS,
                        {(COLUMN_PLAYER_ID, _playerId)},
                        COLUMN_CHARACTER_ID))
            End If
            Return Nothing
        End Get
        Set(value As ICharacterStore)
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
DELETE FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {COLUMN_PLAYER_ID}=@{COLUMN_PLAYER_ID};"
                command.Parameters.AddWithValue($"@{COLUMN_PLAYER_ID}", _playerId)
                command.ExecuteNonQuery()
            End Using
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
INSERT INTO 
    {TABLE_PLAYER_CHARACTERS}
    (
        {COLUMN_PLAYER_ID},
        {COLUMN_CHARACTER_ID}
    ) 
    VALUES 
    (
        @{COLUMN_PLAYER_ID},
        @{COLUMN_CHARACTER_ID}
    );"
                command.Parameters.AddWithValue($"@{COLUMN_PLAYER_ID}", _playerId)
                command.Parameters.AddWithValue($"@{COLUMN_CHARACTER_ID}", value.Id)
                command.ExecuteNonQuery()
            End Using
        End Set
    End Property

    Private ReadOnly Property Store As IDataStore
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public Function CreateCharacter(
                                   characterName As String,
                                   location As ILocationStore,
                                   characterType As ICharacterTypeStore,
                                   statistics As IReadOnlyDictionary(Of IStatisticTypeStore, Integer)
                                   ) As ICharacterStore Implements IPlayerStore.CreateCharacter
        Dim character = Store.CreateCharacter(characterName, location, characterType)
        For Each entry In statistics
            character.AddStatistic(entry.Key, entry.Value)
        Next
        Return character
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer) Implements IPlayerStore.GetCharacterTypeGenerator
        Return Store.GetCharacterTypeGenerator
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer) Implements IPlayerStore.GetLocationGenerator
        Return Store.GetLocationGenerator
    End Function
End Class
