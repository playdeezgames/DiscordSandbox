Imports Microsoft.Data.SqlClient

Public Class EffectTypeStatisticDeltaStore
    Implements IEffectTypeStatisticDeltaStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly id As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        Me.connectionSource = connectionSource
        Me.id = id
    End Sub

    Public ReadOnly Property StatisticType As IStatisticTypeStore Implements IEffectTypeStatisticDeltaStore.StatisticType
        Get
            Return New StatisticTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_EFFECT_TYPE_STATISTIC_DELTAS,
                    {(COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID, id)},
                    COLUMN_STATISTIC_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property Delta As Integer Implements IEffectTypeStatisticDeltaStore.Delta
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_EFFECT_TYPE_STATISTIC_DELTAS,
                {(COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID, id)},
                COLUMN_STATISTIC_VALUE)
        End Get
    End Property
End Class
