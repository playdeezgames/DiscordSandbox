Public Interface ILocationStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property LocationType As ILocationTypeStore
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore)
End Interface
