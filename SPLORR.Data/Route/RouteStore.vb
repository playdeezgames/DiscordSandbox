Imports Microsoft.Data.SqlClient

Friend Class RouteStore
    Implements IRouteStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IRouteStore.Id

    Public Sub New(connectionSource As Func(Of SqlConnection), routeId As Integer)
        Me._connectionSource = connectionSource
        Me.Id = routeId
    End Sub

    Public ReadOnly Property RouteType As IRouteTypeStore Implements IRouteStore.RouteType
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_ROUTE_TYPE_ID} 
FROM 
    {TABLE_ROUTES} 
WHERE 
    {COLUMN_ROUTE_ID}={PARAMETER_ROUTE_ID};"
                command.Parameters.AddWithValue(PARAMETER_ROUTE_ID, Id)
                Return New RouteTypeStore(_connectionSource, CInt(command.ExecuteScalar))
            End Using
        End Get
    End Property

    Public ReadOnly Property Direction As IDirectionStore Implements IRouteStore.Direction
        Get
            Return New DirectionStore(_connectionSource, _connectionSource.ReadIntegerForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id), COLUMN_DIRECTION_ID))
        End Get
    End Property

    Public ReadOnly Property FromLocation As ILocationStore Implements IRouteStore.FromLocation
        Get
            Return New LocationStore(_connectionSource, _connectionSource.ReadIntegerForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id), COLUMN_FROM_LOCATION_ID))
        End Get
    End Property

    Public ReadOnly Property ToLocation As ILocationStore Implements IRouteStore.ToLocation
        Get
            Return New LocationStore(_connectionSource, _connectionSource.ReadIntegerForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id), COLUMN_TO_LOCATION_ID))
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IRouteStore.Name
        Get
            Return Direction.Name
        End Get
    End Property
End Class
