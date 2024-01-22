Public Interface ILocationStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IRelatedTypeStore(Of IRouteStore)
    Function FindRouteByDirectionName(directionName As String) As IRouteStore
    Function AddRoute(direction As IDirectionStore, routeType As IRouteTypeStore, toLocation As ILocationStore) As IRouteStore
    Property LocationType As ILocationTypeStore
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore)
    ReadOnly Property AvailableDirections As IRelatedTypeStore(Of IDirectionStore)
    ReadOnly Property CanAddRoute As Boolean
End Interface
