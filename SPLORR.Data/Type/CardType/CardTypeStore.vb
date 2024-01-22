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
            Return Not HasDeltas AndAlso Not HasTags
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

    Public ReadOnly Property Tags As IRelatedTypeStore(Of ICardTypeTagStore) Implements ICardTypeStore.Tags
        Get
            Return New RelatedTypeStore(Of ICardTypeTagStore, Integer)(
                connectionSource,
                TABLE_CARD_TYPE_TAGS,
                COLUMN_CARD_TYPE_TAG_ID,
                COLUMN_TAG_NAME,
                (COLUMN_CARD_TYPE_ID, Id),
                Function(x, y) New CardTypeTagStore(x, y))
        End Get
    End Property

    Public Property DeleteOnPlay As Boolean Implements ICardTypeStore.DeleteOnPlay
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPES,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_DELETE_ON_PLAY, 1))
        End Get
        Set(value As Boolean)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPES,
                {(COLUMN_CARD_TYPE_ID, Id)},
                {(COLUMN_DELETE_ON_PLAY, If(value, 1, 0))})
        End Set
    End Property

    Private ReadOnly Property HasDeltas As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                (COLUMN_CARD_TYPE_ID, Id))
        End Get
    End Property

    Private ReadOnly Property HasTags As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_TAGS,
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
                (COLUMN_STATISTIC_DELTA, delta)))
    End Function

    Public Function TagExists(tagName As String) As Boolean Implements ICardTypeStore.TagExists
        Return connectionSource.CheckForValues(
            TABLE_CARD_TYPE_TAGS,
            {(COLUMN_CARD_TYPE_ID, Id),
            (COLUMN_TAG_NAME, tagName)})
    End Function

    Public Function CreateTag(tagName As String) As ICardTypeTagStore Implements ICardTypeStore.CreateTag
        Return New CardTypeTagStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARD_TYPE_TAGS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_TAG_NAME, tagName)))
    End Function
End Class
