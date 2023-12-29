Public Interface ICharacterModel
    Property Name As String
    Property Location As ILocationModel
    Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String())
End Interface
