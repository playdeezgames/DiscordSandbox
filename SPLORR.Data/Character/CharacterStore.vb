Imports System.Reflection.Metadata.Ecma335
Imports Microsoft.Data.SqlClient

Friend Class CharacterStore
    Implements ICharacterStore
    Private ReadOnly connectionSource As Func(Of SqlConnection)

    Public Sub New(connectionSource As Func(Of SqlConnection), characterId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = characterId
    End Sub

    Public ReadOnly Property Id As Integer Implements ICharacterStore.Id

    Public Property Name As String Implements ICharacterStore.Name
        Get
            Return connectionSource.ReadStringForValues(
                TABLE_CHARACTERS,
                {(COLUMN_CHARACTER_ID, Id)},
                COLUMN_CHARACTER_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTERS,
                {(COLUMN_CHARACTER_ID, Id)},
                {(COLUMN_CHARACTER_NAME, value)})
        End Set
    End Property

    Public ReadOnly Property Location As ILocationStore Implements ICharacterStore.Location
        Get
            Return New LocationStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTERS,
                    {(COLUMN_CHARACTER_ID, Id)},
                    COLUMN_LOCATION_ID))
        End Get
    End Property

    Public Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset) Implements ICharacterStore.SetLocation
        connectionSource.WriteValuesForValues(
            TABLE_CHARACTERS,
            {
                (COLUMN_CHARACTER_ID, Id)
            },
            {
                (COLUMN_LOCATION_ID, location.Id),
                (COLUMN_LAST_MODIFIED, lastModified)
            })
    End Sub

    Public Sub Delete() Implements IBaseTypeStore(Of IDataStore).Delete
        connectionSource.DeleteForValues(TABLE_CHARACTERS, (COLUMN_CHARACTER_ID, Id))
    End Sub

    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore(Of IDataStore).CanRenameTo
        Return True
    End Function

    Public Sub ClearPlayer() Implements ICharacterStore.ClearPlayer
        connectionSource.DeleteForValues(
            TABLE_PLAYER_CHARACTERS,
            (COLUMN_CHARACTER_ID, Id))
    End Sub

    Public Function AddStatistic(
                                statisticType As IStatisticTypeStore,
                                statisticValue As Integer,
                                minimumValue As Integer?,
                                maximumValue As Integer?) As ICharacterStatisticStore Implements ICharacterStore.AddStatistic
        Dim columns As New List(Of (String, Object)) From
            {
                (COLUMN_CHARACTER_ID, Id),
                (COLUMN_STATISTIC_TYPE_ID, statisticType.Id),
                (COLUMN_STATISTIC_VALUE, statisticValue)
            }
        If minimumValue.HasValue Then
            columns.Add((COLUMN_MINIMUM_VALUE, minimumValue.Value))
        End If
        If maximumValue.HasValue Then
            columns.Add((COLUMN_MAXIMUM_VALUE, maximumValue.Value))
        End If
        Return New CharacterStatisticStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CHARACTER_STATISTICS,
                columns.ToArray))
    End Function

    Public ReadOnly Property HasOtherCharacters As Boolean Implements ICharacterStore.HasOtherCharacters
        Get
            Return connectionSource.ReadIntegerForValues(
                VIEW_CHARACTER_LOCATION_OTHER_CHARACTERS,
                {(COLUMN_CHARACTER_ID, Id)},
                "COUNT(1)") > 0
        End Get
    End Property

    Public ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore) Implements ICharacterStore.OtherCharacters
        Get
            Return connectionSource.ReadIntegersForValues(
                VIEW_CHARACTER_LOCATION_OTHER_CHARACTERS,
                {(COLUMN_CHARACTER_ID, Id)},
                Array.Empty(Of (Name As String, Value As String))(),
                COLUMN_OTHER_CHARACTER_ID).Select(Function(x) New CharacterStore(connectionSource, x))
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements ICharacterStore.CanDelete
        Get
            Return Not HasPlayer AndAlso Not HasCards AndAlso Not HasStatistics
        End Get
    End Property

    Private ReadOnly Property HasStatistics As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_CHARACTER_STATISTICS, (COLUMN_CHARACTER_ID, Id))
        End Get
    End Property

    Private ReadOnly Property HasCards As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_CARDS, (COLUMN_CHARACTER_ID, Id))
        End Get
    End Property

    Public ReadOnly Property HasPlayer As Boolean Implements ICharacterStore.HasPlayer
        Get
            Return connectionSource.CheckForValues(TABLE_PLAYER_CHARACTERS, (COLUMN_CHARACTER_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore(Of IDataStore).Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public Property CharacterType As ICharacterTypeStore Implements ICharacterStore.CharacterType
        Get
            Return New CharacterTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTERS,
                    {(COLUMN_CHARACTER_ID, Id)},
                    COLUMN_CHARACTER_TYPE_ID))
        End Get
        Set(value As ICharacterTypeStore)
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTERS,
                {(COLUMN_CHARACTER_ID, Id)},
                {(COLUMN_CHARACTER_TYPE_ID, value.Id)})
        End Set
    End Property
    Public ReadOnly Property Cards As IDeckStore Implements ICharacterStore.Cards
        Get
            Return New DeckStore(connectionSource, Me)
        End Get
    End Property

    Public ReadOnly Property Statistics As IRelatedTypeStore(Of ICharacterStatisticStore) Implements ICharacterStore.Statistics
        Get
            Return New RelatedTypeStore(Of ICharacterStatisticStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_STATISTIC_DETAILS,
                COLUMN_CHARACTER_STATISTIC_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CHARACTER_ID, Id),
                Function(x, y) New CharacterStatisticStore(x, y))
        End Get
    End Property

    Public ReadOnly Property AvailableStatistics As IRelatedTypeStore(Of IStatisticTypeStore) Implements ICharacterStore.AvailableStatistics
        Get
            Return New RelatedTypeStore(Of IStatisticTypeStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_AVAILABLE_STATISTICS,
                COLUMN_STATISTIC_TYPE_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CHARACTER_ID, Id),
                Function(x, y) New StatisticTypeStore(x, y))
        End Get
    End Property
End Class
