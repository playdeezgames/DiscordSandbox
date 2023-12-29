Imports SPLORR.Data

Friend Class DirectionModel
    Implements IDirectionModel

    Private ReadOnly _directionStore As IDirectionStore

    Public Sub New(directionStore As IDirectionStore)
        Me._directionStore = directionStore
    End Sub

    Public ReadOnly Property Name As String Implements IDirectionModel.Name
        Get
            Return _directionStore.Name
        End Get
    End Property
End Class
