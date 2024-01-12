Public Interface IRouteStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    Property RouteType As IRouteTypeStore
    Property Direction As IDirectionStore
    Property FromLocation As ILocationStore
    Property ToLocation As ILocationStore
    Sub Delete()
    ReadOnly Property Store As IDataStore
End Interface
