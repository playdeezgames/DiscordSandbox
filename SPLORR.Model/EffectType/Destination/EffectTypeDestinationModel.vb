Imports SPLORR.Data

Friend Class EffectTypeDestinationModel
    Implements IEffectTypeDestinationModel

    Private ReadOnly store As IEffectTypeDestinationStore

    Public Sub New(store As IEffectTypeDestinationStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeDestinationModel.Name
        Get
            Return store.Name
        End Get
    End Property

    Public ReadOnly Property GeneratorWeight As Integer Implements IEffectTypeDestinationModel.GeneratorWeight
        Get
            Return store.GeneratorWeight
        End Get
    End Property

    Public ReadOnly Property Location As ILocationModel Implements IEffectTypeDestinationModel.Location
        Get
            Return New LocationModel(store.Location)
        End Get
    End Property

    Public Function AsPercentage(totalWeight As Integer) As Double Implements IEffectTypeDestinationModel.AsPercentage
        Return GeneratorWeight * 100.0 / totalWeight
    End Function
End Class
