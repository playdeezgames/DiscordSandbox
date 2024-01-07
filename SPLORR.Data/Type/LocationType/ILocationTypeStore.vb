Public Interface ILocationTypeStore
    Inherits IBaseTypeStore
    ReadOnly Property HasLocations As Boolean
    Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore)
    Property ItemTypeGenerator As IItemTypeGeneratorStore
End Interface
