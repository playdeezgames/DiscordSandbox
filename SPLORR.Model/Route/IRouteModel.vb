Public Interface IRouteModel
    ReadOnly Property RouteType As IRouteTypeModel
    ReadOnly Property Direction As IDirectionModel
    ReadOnly Property FromLocation As ILocationModel
    ReadOnly Property ToLocation As ILocationModel
End Interface
