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
            Return connectionSource.ReadStringForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, locationId)},
                COLUMN_LOCATION_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteValuesForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, Id)},
                {(COLUMN_LOCATION_NAME, value)})
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
    {COLUMN_FROM_LOCATION_ID}=@{COLUMN_LOCATION_ID};"
                command.Parameters.AddWithValue($"@{COLUMN_LOCATION_ID}", locationId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property Routes As IRelatedTypeStore(Of IRouteStore) Implements ILocationStore.Routes
        Get
            Return New RelatedTypeStore(Of IRouteStore, Integer)(
                connectionSource,
                VIEW_ROUTE_DETAILS,
                COLUMN_ROUTE_ID,
                COLUMN_ROUTE_NAME,
                (COLUMN_FROM_LOCATION_ID, Id),
                Function(x, y) New RouteStore(x, y))
        End Get
    End Property

    Public ReadOnly Property Inventory As IInventoryStore Implements ILocationStore.Inventory
        Get
            Dim inventoryId = connectionSource.FindIntegerForValues(
                TABLE_INVENTORIES,
                {(COLUMN_LOCATION_ID, locationId)},
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
        @{COLUMN_LOCATION_ID}
    );"
                command.Parameters.AddWithValue($"@{COLUMN_LOCATION_ID}", locationId)
                command.ExecuteNonQuery()
            End Using
            Return New InventoryStore(connectionSource, connectionSource.ReadLastIdentity)
        End Get
    End Property

    Public Property LocationType As ILocationTypeStore Implements ILocationStore.LocationType
        Get
            Return New LocationTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_LOCATIONS,
                    {(COLUMN_LOCATION_ID, locationId)},
                    COLUMN_LOCATION_TYPE_ID))
        End Get
        Set(value As ILocationTypeStore)
            connectionSource.WriteValuesForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, Id)},
                {(COLUMN_LOCATION_TYPE_ID, value.Id)})
        End Set
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
        Get
            Return Not HasCharacters AndAlso
                Not HasRoutes AndAlso
                Not IsDestination AndAlso
                Not HasInventory
        End Get
    End Property

    Private ReadOnly Property HasCharacters As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_CHARACTERS, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Private ReadOnly Property IsDestination As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_ROUTES, (COLUMN_TO_LOCATION_ID, Id))
        End Get
    End Property

    Private ReadOnly Property HasInventory As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_INVENTORIES, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public ReadOnly Property HasCharacter As Boolean Implements ILocationStore.HasCharacter
        Get
            Return connectionSource.CheckForValues(TABLE_CHARACTERS, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore) Implements ILocationStore.Characters
        Get
            Return New RelatedTypeStore(Of ICharacterStore, Integer)(
                connectionSource,
                TABLE_CHARACTERS,
                COLUMN_CHARACTER_ID,
                COLUMN_CHARACTER_NAME,
                (COLUMN_LOCATION_ID, Id),
                Function(x, y) New CharacterStore(x, y))
        End Get
    End Property

    Public ReadOnly Property AvailableDirections As IRelatedTypeStore(Of IDirectionStore) Implements ILocationStore.AvailableDirections
        Get
            Return New RelatedTypeStore(Of IDirectionStore, Integer)(
                connectionSource,
                VIEW_LOCATION_AVAILABLE_DIRECTIONS,
                COLUMN_DIRECTION_ID,
                COLUMN_DIRECTION_NAME,
                (COLUMN_LOCATION_ID, Id),
                Function(x, y) New DirectionStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddRoute As Boolean Implements ILocationStore.CanAddRoute
        Get
            Return connectionSource.CheckForValues(
                VIEW_LOCATION_AVAILABLE_DIRECTIONS,
                (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Public Sub Delete() Implements IBaseTypeStore.Delete
        connectionSource.DeleteForValues(TABLE_LOCATIONS, (COLUMN_LOCATION_ID, Id))
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
    r.{COLUMN_FROM_LOCATION_ID}=@{COLUMN_LOCATION_ID} 
    AND d.{COLUMN_DIRECTION_NAME}=@{COLUMN_DIRECTION_NAME};"
            command.Parameters.AddWithValue($"@{COLUMN_LOCATION_ID}", locationId)
            command.Parameters.AddWithValue($"@{COLUMN_DIRECTION_NAME}", directionName)
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

    Public Function AddRoute(direction As IDirectionStore, routeType As IRouteTypeStore, toLocation As ILocationStore) As IRouteStore Implements ILocationStore.AddRoute
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_ROUTES}
    (
        {COLUMN_DIRECTION_ID},
        {COLUMN_ROUTE_TYPE_ID},
        {COLUMN_FROM_LOCATION_ID},
        {COLUMN_TO_LOCATION_ID}
    ) 
    VALUES 
    (
        @{COLUMN_DIRECTION_ID},
        @{COLUMN_ROUTE_TYPE_ID},
        @{COLUMN_FROM_LOCATION_ID},
        @{COLUMN_TO_LOCATION_ID}
    );"
            command.Parameters.AddWithValue($"@{COLUMN_DIRECTION_ID}", direction.Id)
            command.Parameters.AddWithValue($"@{COLUMN_ROUTE_TYPE_ID}", routeType.Id)
            command.Parameters.AddWithValue($"@{COLUMN_FROM_LOCATION_ID}", Id)
            command.Parameters.AddWithValue($"@{COLUMN_TO_LOCATION_ID}", toLocation.Id)
            command.ExecuteNonQuery()
        End Using
        Return New RouteStore(
            connectionSource,
            connectionSource.ReadLastIdentity)
    End Function
End Class
