Public Interface ILocationStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRouteStore)
    ReadOnly Property Inventory As IInventoryStore
    Function FindRouteByDirectionName(directionName As String) As IRouteStore
    ReadOnly Property LocationType As ILocationTypeStore
End Interface
