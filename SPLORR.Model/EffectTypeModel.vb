Imports SPLORR.Data

Public Class EffectTypeModel
    Implements IEffectTypeModel

    Private store As IEffectTypeStore

    Public Sub New(store As IEffectTypeStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeModel.Name
        Get
            Return store.Name
        End Get
    End Property

    Public ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaModel) Implements IEffectTypeModel.StatisticDeltas
        Get
            Return store.StatisticDeltas.Select(Function(x) New EffectTypeStatisticDeltaModel(x))
        End Get
    End Property
End Class
