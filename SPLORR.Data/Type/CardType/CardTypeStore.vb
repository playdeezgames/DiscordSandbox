Imports Microsoft.Data.SqlClient

Friend Class CardTypeStore
    Inherits BaseTypeStore
    Implements ICardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPES,
            COLUMN_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasDeltas
        End Get
    End Property

    Public ReadOnly Property StatisticDeltas As IRelatedTypeStore(Of ICardTypeStatisticDeltaStore) Implements ICardTypeStore.StatisticDeltas
        Get
            Return New RelatedTypeStore(Of ICardTypeStatisticDeltaStore, Integer)(
                connectionSource,
                VIEW_CARD_TYPE_STATISTIC_DELTA_DETAILS,
                COLUMN_CARD_TYPE_STATISTIC_DELTA_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CARD_TYPE_ID, Id),
                Function(x, y) New CardTypeStatisticDeltaStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddStatisticDelta As Boolean Implements ICardTypeStore.CanAddStatisticDelta
        Get
            Return connectionSource.CheckForValues(VIEW_CARD_TYPE_AVAILABLE_STATISTIC_DELTAS, (COLUMN_CARD_TYPE_ID, Id))
        End Get
    End Property

    Public ReadOnly Property AvailableStatisticDeltas As IRelatedTypeStore(Of IStatisticTypeStore) Implements ICardTypeStore.AvailableStatisticDeltas
        Get
            Return New RelatedTypeStore(Of IStatisticTypeStore, Integer)(
                connectionSource,
                VIEW_CARD_TYPE_AVAILABLE_STATISTIC_DELTAS,
                COLUMN_STATISTIC_TYPE_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CARD_TYPE_ID, Id),
                Function(x, y) New StatisticTypeStore(x, y))
        End Get
    End Property

    Private ReadOnly Property HasDeltas As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                (COLUMN_CARD_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateCard(store As ICharacterStore) As ICardStore Implements ICardTypeStore.CreateCard
        Return New CardStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARDS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_CHARACTER_ID, store.Id)))
    End Function

    Public Function AddStatisticDelta(statisticType As IStatisticTypeStore, delta As Integer) As ICardTypeStatisticDeltaStore Implements ICardTypeStore.AddStatisticDelta
        Return New CardTypeStatisticDeltaStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_STATISTIC_TYPE_ID, statisticType.Id),
                (COLUMN_ALLOW_OVERAGE, 0),
                (COLUMN_ALLOW_DEFICIT, 0),
                (COLUMN_STATISTIC_DELTA, delta)))
    End Function
End Class
