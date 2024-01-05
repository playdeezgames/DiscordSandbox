Public Interface ILocationTypeStore
    Inherits IBaseTypeStore
    ReadOnly Property HasLocations As Boolean
    ReadOnly Property HasVerbs As Boolean
    ReadOnly Property CanAddVerb As Boolean
    ReadOnly Property AvailableVerbTypes As IEnumerable(Of IVerbTypeStore)
    ReadOnly Property VerbTypes As IEnumerable(Of IVerbTypeStore)
    Sub AddVerb(verbTypeStore As IVerbTypeStore)
    Sub RemoveVerb(verbTypeStore As IVerbTypeStore)
    Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore)
    Function FilterVerbTypes(filter As String) As IEnumerable(Of IVerbTypeStore)
End Interface
