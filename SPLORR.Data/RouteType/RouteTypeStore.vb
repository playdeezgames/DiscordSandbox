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
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {FIELD_ROUTE_TYPE_NAME} 
FROM 
    {TABLE_ROUTE_TYPES} 
WHERE 
    {FIELD_ROUTE_TYPE_ID}={PARAMETER_ROUTE_TYPE_ID};"
                command.Parameters.AddWithValue(PARAMETER_ROUTE_TYPE_ID, _routeTypeId)
                Return CStr(command.ExecuteScalar)
            End Using
        End Get
    End Property
End Class
