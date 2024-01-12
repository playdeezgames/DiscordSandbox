﻿Public Interface ILocationStore
    Inherits IBaseTypeStore
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IRelatedTypeStore(Of IRouteStore)
    ReadOnly Property Inventory As IInventoryStore
    Function FindRouteByDirectionName(directionName As String) As IRouteStore
    Property LocationType As ILocationTypeStore
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore)
    ReadOnly Property AvailableDirections As IRelatedTypeStore(Of IDirectionStore)
End Interface
