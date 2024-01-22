Imports SPLORR.Data

Public Interface ILocationModel
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRouteModel)
    Function FindRouteByDirectionName(directionName As String) As IRouteModel
    Function IsSameAs(otherLocation As ILocationModel) As Boolean
    ReadOnly Property LocationStore As ILocationStore
End Interface
