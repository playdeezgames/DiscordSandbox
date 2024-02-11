Imports SPLORR.Data

Public Class EffectTypeStatisticDeltaModel
    Implements IEffectTypeStatisticDeltaModel

    Private ReadOnly store As IEffectTypeStatisticDeltaStore

    Public Sub New(store As IEffectTypeStatisticDeltaStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeStatisticDeltaModel.Name
        Get
            Return store.StatisticType.Name
        End Get
    End Property

    Public ReadOnly Property Delta As Integer Implements IEffectTypeStatisticDeltaModel.Delta
        Get
            Return store.Delta
        End Get
    End Property
End Class
