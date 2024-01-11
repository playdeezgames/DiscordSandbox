Public Interface IRouteStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    ReadOnly Property RouteType As IRouteTypeStore
    ReadOnly Property Direction As IDirectionStore
    ReadOnly Property FromLocation As ILocationStore
    ReadOnly Property ToLocation As ILocationStore
End Interface
