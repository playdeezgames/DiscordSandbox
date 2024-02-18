Imports SPLORR.Data

Public Class EffectTypeModel
    Implements IEffectTypeModel

    Public ReadOnly Property Store As IEffectTypeStore Implements IEffectTypeModel.Store

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

    Public ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementModel) Implements IEffectTypeModel.Requirements
        Get
            Return store.Requirements.Select(Function(x) New EffectTypeStatisticRequirementModel(x))
        End Get
    End Property

    Public ReadOnly Property LocationType As ILocationTypeModel Implements IEffectTypeModel.LocationType
        Get
            Dim locationTypeStore = store.LocationType
            If locationTypeStore Is Nothing Then
                Return Nothing
            End If
            Return New LocationTypeModel(locationTypeStore)
        End Get
    End Property

    Public ReadOnly Property Destinations As IEnumerable(Of IEffectTypeDestinationModel) Implements IEffectTypeModel.Destinations
        Get
            Return store.Destinations.Select(Function(x) New EffectTypeDestinationModel(x))
        End Get
    End Property

    Public ReadOnly Property CardTypeGenerators As IEnumerable(Of IEffectTypeCardTypeGeneratorModel) Implements IEffectTypeModel.CardTypeGenerators
        Get
            Return store.CardTypeGenerators.Select(Function(x) New EffectTypeCardTypeGeneratorModel(x))
        End Get
    End Property

    Public ReadOnly Property RefreshHand As Boolean Implements IEffectTypeModel.RefreshHand
        Get
            Return Store.RefreshHand
        End Get
    End Property
End Class
