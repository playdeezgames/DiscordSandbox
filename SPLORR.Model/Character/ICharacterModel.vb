Public Interface ICharacterModel
    Property Name As String
    Property Location As ILocationModel
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel)
    Sub DoVerb(verbType As IVerbTypeModel, outputter As Action(Of String))
    Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String())
    Function CanDoVerb(verbType As IVerbTypeModel) As Boolean
End Interface
