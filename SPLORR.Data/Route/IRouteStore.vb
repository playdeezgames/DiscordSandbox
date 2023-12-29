Public Interface IRouteStore
    ReadOnly Property RouteType As IRouteTypeStore
    ReadOnly Property Direction As IDirectionStore
    ReadOnly Property FromLocation As ILocationStore
    ReadOnly Property ToLocation As ILocationStore
End Interface
