Public Interface ILocationStore
    Inherits IBaseTypeStore
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRouteStore)
    ReadOnly Property Inventory As IInventoryStore
    Function FindRouteByDirectionName(directionName As String) As IRouteStore
    Property LocationType As ILocationTypeStore
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore)
End Interface
