Imports SPLORR.Data

Public Class CardStatisticDeltaModel
    Implements ICardStatisticDeltaModel

    Private ReadOnly store As ICardStatisticDeltaStore

    Public Sub New(store As ICardStatisticDeltaStore)
        Me.store = store
    End Sub

    Public ReadOnly Property StatisticType As IStatisticTypeModel Implements ICardStatisticDeltaModel.StatisticType
        Get
            Return New StatisticTypeModel(store.StatisticType)
        End Get
    End Property

    Public ReadOnly Property Delta As Integer Implements ICardStatisticDeltaModel.Delta
        Get
            Return store.Delta
        End Get
    End Property
End Class
