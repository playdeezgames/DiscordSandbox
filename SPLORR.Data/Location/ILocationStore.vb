Public Interface ILocationStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRouteStore)
End Interface
