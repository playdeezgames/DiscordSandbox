Public Interface ICharacterModel
    Property Name As String
    Property Location As ILocationModel
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel)
    Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String())
End Interface
