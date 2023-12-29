Imports SPLORR.Data

Friend Class RouteModel
    Implements IRouteModel
    Private ReadOnly _routeStore As IRouteStore

    Public Sub New(routeStore As IRouteStore)
        Me._routeStore = routeStore
    End Sub

    Public ReadOnly Property RouteType As IRouteTypeModel Implements IRouteModel.RouteType
        Get
            Return New RouteTypeModel(_routeStore.RouteType)
        End Get
    End Property

    Public ReadOnly Property Direction As IDirectionModel Implements IRouteModel.Direction
        Get
            Return New DirectionModel(_routeStore.Direction)
        End Get
    End Property
End Class
