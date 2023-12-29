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

    Public ReadOnly Property HasRoutes As Boolean Implements ILocationModel.HasRoutes
        Get
            Return _locationStore.HasRoutes
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRouteModel) Implements ILocationModel.Routes
        Get
            Return _locationStore.Routes.Select(Function(x) New RouteModel(x))
        End Get
    End Property
End Class
