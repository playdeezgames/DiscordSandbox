Friend Class LocationModel
    Implements ILocationModel

    Private _locationStore As Data.ILocationStore

    Public Sub New(locationStore As Data.ILocationStore)
        Me._locationStore = locationStore
    End Sub

    Public ReadOnly Property Name As String Implements ILocationModel.Name
        Get
            Return _locationStore.Name
        End Get
    End Property
End Class
