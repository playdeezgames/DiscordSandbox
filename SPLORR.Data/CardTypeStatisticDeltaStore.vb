Imports Microsoft.Data.SqlClient

Friend Class CardTypeStatisticDeltaStore
    Implements ICardTypeStatisticDeltaStore

    Private connectionSource As Func(Of SqlConnection)
    Private id As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        Me.connectionSource = connectionSource
        Me.id = id
    End Sub

    Public ReadOnly Property StatisticType As IStatisticTypeStore Implements ICardTypeStatisticDeltaStore.StatisticType
        Get
            Return New StatisticTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARD_TYPE_STATISTIC_DELTAS,
                    {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, id)},
                    COLUMN_STATISTIC_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property Delta As Integer Implements ICardTypeStatisticDeltaStore.Delta
        Get
            Return connectionSource.ReadIntegerForValues(
                                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                                {(COLUMN_CARD_TYPE_STATISTIC_DELTA_ID, id)},
                                COLUMN_STATISTIC_DELTA)
        End Get
    End Property
End Class
