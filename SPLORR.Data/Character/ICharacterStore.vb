Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    ReadOnly Property Location As ILocationStore
    Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset)
    Function CanDoVerb(verbType As IVerbTypeStore) As Boolean
    Property Name As String
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore)
End Interface
