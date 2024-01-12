Public Interface IRouteStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    Property RouteType As IRouteTypeStore
    Property Direction As IDirectionStore
    ReadOnly Property FromLocation As ILocationStore
    ReadOnly Property ToLocation As ILocationStore
    Sub Delete()
    ReadOnly Property Store As IDataStore
End Interface
