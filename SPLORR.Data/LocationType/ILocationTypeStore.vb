Public Interface ILocationTypeStore
    Property Name As String
    ReadOnly Property Id As Integer
    ReadOnly Property CanDelete As Boolean
    ReadOnly Property HasLocations As Boolean
    ReadOnly Property HasVerbs As Boolean
    ReadOnly Property CanAddVerb As Boolean
    ReadOnly Property AvailableVerbTypes As IEnumerable(Of IVerbTypeStore)
    Sub Delete()
    Sub AddVerb(verbTypeStore As IVerbTypeStore)
    Function CanRenameTo(name As String) As Boolean
    Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore)
    Function FilterVerbTypes(filter As String) As IEnumerable(Of IVerbTypeStore)
End Interface
