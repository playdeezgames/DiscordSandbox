Imports SPLORR.Data

Public Interface ILocationModel
    ReadOnly Property Name As String
    Function IsSameAs(otherLocation As ILocationModel) As Boolean
    ReadOnly Property LocationStore As ILocationStore
End Interface
