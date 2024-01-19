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
            Return connectionSource.ReadIntegerForValues(TABLE_PLAYER_CHARACTERS, {(COLUMN_PLAYER_ID, _playerId)}, "COUNT(1)") > 0
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
            connectionSource.DeleteForValues(
                TABLE_PLAYER_CHARACTERS,
                (COLUMN_PLAYER_ID, _playerId))
            connectionSource.Insert(
                TABLE_PLAYER_CHARACTERS,
                (COLUMN_PLAYER_ID, _playerId),
                (COLUMN_CHARACTER_ID, value.Id))
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
                                   statistics As IReadOnlyDictionary(Of IStatisticTypeStore, (Value As Integer, Minimum As Integer?, Maximum As Integer?))
                                   ) As ICharacterStore Implements IPlayerStore.CreateCharacter
        Dim character = Store.CreateCharacter(characterName, location, characterType)
        For Each entry In statistics
            character.AddStatistic(entry.Key, entry.Value.Value, entry.Value.Minimum, entry.Value.Maximum)
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
