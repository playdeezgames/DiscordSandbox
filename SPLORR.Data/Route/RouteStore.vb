Imports Microsoft.Data.SqlClient

Friend Class RouteStore
    Implements IRouteStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _routeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), routeId As Integer)
        Me._connectionSource = connectionSource
        Me._routeId = routeId
    End Sub

    Public ReadOnly Property RouteType As IRouteTypeStore Implements IRouteStore.RouteType
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {FIELD_ROUTE_TYPE_ID} 
FROM 
    {TABLE_ROUTES} 
WHERE 
    {FIELD_ROUTE_ID}={PARAMETER_ROUTE_ID};"
                command.Parameters.AddWithValue(PARAMETER_ROUTE_ID, _routeId)
                Return New RouteTypeStore(_connectionSource, CInt(command.ExecuteScalar))
            End Using
        End Get
    End Property

    Public ReadOnly Property Direction As IDirectionStore Implements IRouteStore.Direction
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {FIELD_DIRECTION_ID} 
FROM 
    {TABLE_ROUTES} 
WHERE 
    {FIELD_ROUTE_ID}={PARAMETER_ROUTE_ID};"
                command.Parameters.AddWithValue(PARAMETER_ROUTE_ID, _routeId)
                Return New DirectionStore(_connectionSource, CInt(command.ExecuteScalar))
            End Using
        End Get
    End Property
End Class
