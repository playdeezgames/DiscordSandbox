Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    ReadOnly Property Location As ILocationStore
    Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset)
    Property Name As String
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore)
End Interface
