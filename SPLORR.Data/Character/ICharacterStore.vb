Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    Property Location As ILocationStore
    Property Name As String
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore)
End Interface
