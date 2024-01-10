Imports Microsoft.Data.SqlClient

Friend Class LocationStore
    Implements ILocationStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly locationId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationId As Integer)
        Me.connectionSource = connectionSource
        Me.locationId = locationId
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocationStore.Id
        Get
            Return locationId
        End Get
    End Property

    Public Property Name As String Implements ILocationStore.Name
        Get
            Return connectionSource.ReadStringForValue(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_ID, locationId),
                COLUMN_LOCATION_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteValueForInteger(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_ID, Id),
                (COLUMN_LOCATION_NAME, value))
        End Set
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements ILocationStore.HasRoutes
        Get
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_ROUTES} 
WHERE 
    {COLUMN_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, locationId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRouteStore) Implements ILocationStore.Routes
        Get
            Dim result As New List(Of IRouteStore)
            Using command = connectionSource().CreateCommand
                command.CommandText = $"SELECT {COLUMN_ROUTE_ID} FROM {TABLE_ROUTES} WHERE {COLUMN_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, locationId)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add(New RouteStore(connectionSource, reader.GetInt32(0)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public ReadOnly Property Inventory As IInventoryStore Implements ILocationStore.Inventory
        Get
            Dim inventoryId = connectionSource.FindIntegerForValue(
                TABLE_INVENTORIES,
                (COLUMN_LOCATION_ID, locationId),
                COLUMN_INVENTORY_ID)
            If inventoryId.HasValue Then
                Return New InventoryStore(connectionSource, inventoryId.Value)
            End If
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
INSERT INTO 
    {TABLE_INVENTORIES}
    (
        {COLUMN_LOCATION_ID}
    )
    VALUES
    (
        {PARAMETER_LOCATION_ID}
    );"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, locationId)
                command.ExecuteNonQuery()
            End Using
            Return New InventoryStore(connectionSource, connectionSource.ReadLastIdentity)
        End Get
    End Property

    Public ReadOnly Property LocationType As ILocationTypeStore Implements ILocationStore.LocationType
        Get
            Return New LocationTypeStore(connectionSource, connectionSource.ReadIntegerForValue(TABLE_LOCATIONS, (COLUMN_LOCATION_ID, locationId), COLUMN_LOCATION_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public Sub Delete() Implements IBaseTypeStore.Delete
        connectionSource.DeleteForValue(TABLE_LOCATIONS, (COLUMN_LOCATION_ID, Id))
    End Sub

    Public Function FindRouteByDirectionName(directionName As String) As IRouteStore Implements ILocationStore.FindRouteByDirectionName
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_ROUTE_ID} 
FROM 
    {TABLE_ROUTES} r 
JOIN 
    {TABLE_DIRECTIONS} d ON r.{COLUMN_DIRECTION_ID}=d.{COLUMN_DIRECTION_ID}
WHERE 
    r.{COLUMN_FROM_LOCATION_ID}={PARAMETER_LOCATION_ID} 
    AND d.{COLUMN_DIRECTION_NAME}={PARAMETER_DIRECTION_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, locationId)
            command.Parameters.AddWithValue(PARAMETER_DIRECTION_NAME, directionName)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return New RouteStore(connectionSource, reader.GetInt32(0))
                End If
            End Using
            Return Nothing
        End Using
    End Function

    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
        Return True
    End Function
End Class
