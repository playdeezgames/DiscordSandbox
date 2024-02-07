Imports Microsoft.Data.SqlClient

Public Class CardStatisticDeltaStore
    Implements ICardStatisticDeltaStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly statisticTypeId As Integer
    Private ReadOnly statisticDelta As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), x As (Integer, Integer))
        Me.connectionSource = connectionSource
        statisticTypeId = x.Item1
        statisticDelta = x.Item2
    End Sub

    Public ReadOnly Property StatisticType As IStatisticTypeStore Implements ICardStatisticDeltaStore.StatisticType
        Get
            Return New StatisticTypeStore(connectionSource, statisticTypeId)
        End Get
    End Property

    Public ReadOnly Property Delta As Integer Implements ICardStatisticDeltaStore.Delta
        Get
            Return statisticDelta
        End Get
    End Property
End Class
