Imports Microsoft.Data.SqlClient

Friend Class RouteTypeStore
    Implements IRouteTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _routeTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), routeTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._routeTypeId = routeTypeId
    End Sub

    Public ReadOnly Property Name As String Implements IRouteTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(
                TABLE_ROUTE_TYPES,
                (FIELD_ROUTE_TYPE_ID, _routeTypeId),
                FIELD_ROUTE_TYPE_NAME)
        End Get
    End Property
End Class
