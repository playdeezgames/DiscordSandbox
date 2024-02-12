Imports SPLORR.Data

Friend Class EffectTypeStatisticRequirementModel
    Implements IEffectTypeStatisticRequirementModel

    Private ReadOnly store As IEffectTypeStatisticRequirementStore

    Public Sub New(store As IEffectTypeStatisticRequirementStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeStatisticRequirementModel.Name
        Get
            Return store.Statistic.Name
        End Get
    End Property

    Public ReadOnly Property Minimum As Integer? Implements IEffectTypeStatisticRequirementModel.Minimum
        Get
            Return store.Minimum
        End Get
    End Property

    Public ReadOnly Property Maximum As Integer? Implements IEffectTypeStatisticRequirementModel.Maximum
        Get
            Return store.Maximum
        End Get
    End Property
End Class
