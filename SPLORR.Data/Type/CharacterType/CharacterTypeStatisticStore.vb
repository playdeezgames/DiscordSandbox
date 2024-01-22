Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStatisticStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICharacterTypeStatisticStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CHARACTER_TYPE_STATISTIC_DETAILS,
            COLUMN_CHARACTER_TYPE_STATISTIC_ID,
            COLUMN_STATISTIC_TYPE_NAME,
            New DataStore(connectionSource()),
            TABLE_CHARACTER_TYPE_STATISTICS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property Value As Integer Implements ICharacterTypeStatisticStore.Value
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                COLUMN_STATISTIC_VALUE)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                {(COLUMN_STATISTIC_VALUE, value)})
        End Set
    End Property

    Public ReadOnly Property CharacterType As ICharacterTypeStore Implements ICharacterTypeStatisticStore.CharacterType
        Get
            Return New CharacterTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_TYPE_STATISTICS,
                    {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                    COLUMN_CHARACTER_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property StatisticType As IStatisticTypeStore Implements ICharacterTypeStatisticStore.StatisticType
        Get
            Return New StatisticTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_TYPE_STATISTICS,
                    {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                    COLUMN_STATISTIC_TYPE_ID))
        End Get
    End Property

    Public Property Minimum As Integer? Implements ICharacterTypeStatisticStore.Minimum
        Get
            Return connectionSource.FindIntegerForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                COLUMN_MINIMUM_VALUE)
        End Get
        Set(value As Integer?)
            If Not value.HasValue Then
                connectionSource.ClearColumnForValues(
                    TABLE_CHARACTER_TYPE_STATISTICS,
                    {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                    COLUMN_MINIMUM_VALUE)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                {(COLUMN_MINIMUM_VALUE, value.Value)})
        End Set
    End Property

    Public Property Maximum As Integer? Implements ICharacterTypeStatisticStore.Maximum
        Get
            Return connectionSource.FindIntegerForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                COLUMN_MAXIMUM_VALUE)
        End Get
        Set(value As Integer?)
            If Not value.HasValue Then
                connectionSource.ClearColumnForValues(
                    TABLE_CHARACTER_TYPE_STATISTICS,
                    {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                    COLUMN_MAXIMUM_VALUE)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_TYPE_STATISTICS,
                {(COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id)},
                {(COLUMN_MAXIMUM_VALUE, value.Value)})
        End Set
    End Property
End Class
