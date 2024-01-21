Imports Microsoft.Data.SqlClient

Friend Class CardTypeStatisticDeltaStore
    Inherits BaseTypeStore
    Implements ICardTypeStatisticDeltaStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CARD_TYPE_STATISTIC_DELTA_DETAILS,
            COLUMN_CARD_TYPE_STATISTIC_DELTA_ID,
            COLUMN_STATISTIC_TYPE_NAME,
            TABLE_CARD_TYPE_STATISTIC_DELTAS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property Delta As Integer Implements ICardTypeStatisticDeltaStore.Delta
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id)},
                COLUMN_STATISTIC_DELTA)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id)},
                {(COLUMN_STATISTIC_DELTA, value)})
        End Set
    End Property

    Public ReadOnly Property CardType As ICardTypeStore Implements ICardTypeStatisticDeltaStore.CardType
        Get
            Return New CardTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARD_TYPE_STATISTIC_DELTAS,
                    {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id)},
                    COLUMN_CARD_TYPE_ID))
        End Get
    End Property

    Public Property AllowOverage As Boolean Implements ICardTypeStatisticDeltaStore.AllowOverage
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {
                    (COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id),
                    (COLUMN_ALLOW_OVERAGE, 1)
                },
                "COUNT(1)") > 0
        End Get
        Set(value As Boolean)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id)},
                {(COLUMN_ALLOW_OVERAGE, If(value, 1, 0))})
        End Set
    End Property

    Public Property AllowDeficit As Boolean Implements ICardTypeStatisticDeltaStore.AllowDeficit
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {
                    (COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id),
                    (COLUMN_ALLOW_DEFICIT, 1)
                },
                "COUNT(1)") > 0
        End Get
        Set(value As Boolean)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, Id)},
                {(COLUMN_ALLOW_DEFICIT, If(value, 1, 0))})
        End Set
    End Property
End Class
