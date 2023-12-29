Imports SPLORR.Data

Friend Class RouteTypeModel
    Implements IRouteTypeModel

    Private ReadOnly _routeTypeStore As IRouteTypeStore

    Public Sub New(routeTypeStore As IRouteTypeStore)
        Me._routeTypeStore = routeTypeStore
    End Sub

    Public ReadOnly Property Name As String Implements IRouteTypeModel.Name
        Get
            Return _routeTypeStore.Name
        End Get
    End Property
End Class
