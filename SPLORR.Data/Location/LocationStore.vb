Imports Microsoft.Data.SqlClient

Friend Class LocationStore
    Implements ILocationStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _locationId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationId As Integer)
        Me._connectionSource = connectionSource
        Me._locationId = locationId
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocationStore.Id
        Get
            Return _locationId
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ILocationStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(
                TABLE_LOCATIONS,
                (FIELD_LOCATION_ID, _locationId),
                FIELD_LOCATION_NAME)
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements ILocationStore.HasRoutes
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_ROUTES} 
WHERE 
    {FIELD_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, _locationId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRouteStore) Implements ILocationStore.Routes
        Get
            Dim result As New List(Of IRouteStore)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"SELECT {FIELD_ROUTE_ID} FROM {TABLE_ROUTES} WHERE {FIELD_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, _locationId)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add(New RouteStore(_connectionSource, reader.GetInt32(0)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public Function FindRouteByDirectionName(directionName As String) As IRouteStore Implements ILocationStore.FindRouteByDirectionName
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_ROUTE_ID} 
FROM 
    {TABLE_ROUTES} r 
JOIN 
    {TABLE_DIRECTIONS} d ON r.{FIELD_DIRECTION_ID}=d.{FIELD_DIRECTION_ID}
WHERE 
    r.{FIELD_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID} 
    AND d.{FIELD_DIRECTION_NAME}={PARAMETER_DIRECTION_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, _locationId)
            command.Parameters.AddWithValue(PARAMETER_DIRECTION_NAME, directionName)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return New RouteStore(_connectionSource, reader.GetInt32(0))
                End If
            End Using
            Return Nothing
        End Using
    End Function
End Class
