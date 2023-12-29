Public Interface ILocationModel
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRouteModel)
End Interface
