Imports Microsoft.Data.SqlClient

Friend Class RouteStore
    Implements IRouteStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IRouteStore.Id

    Public Sub New(connectionSource As Func(Of SqlConnection), routeId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = routeId
    End Sub

    Public Sub Delete() Implements IRouteStore.Delete
        connectionSource.DeleteForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id))
    End Sub

    Public Property RouteType As IRouteTypeStore Implements IRouteStore.RouteType
        Get
            Return New RouteTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_ROUTES,
                    (COLUMN_ROUTE_ID, Id),
                    COLUMN_ROUTE_TYPE_ID))
        End Get
        Set(value As IRouteTypeStore)
            connectionSource.WriteValueForInteger(
                TABLE_ROUTES,
                (COLUMN_ROUTE_ID, Id),
                (COLUMN_ROUTE_TYPE_ID, value.Id))
        End Set
    End Property

    Public Property Direction As IDirectionStore Implements IRouteStore.Direction
        Get
            Return New DirectionStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_ROUTES,
                    (COLUMN_ROUTE_ID, Id),
                    COLUMN_DIRECTION_ID))
        End Get
        Set(value As IDirectionStore)
            connectionSource.WriteValueForInteger(
                TABLE_ROUTES,
                (COLUMN_ROUTE_ID, Id),
                (COLUMN_DIRECTION_ID, value.Id))
        End Set
    End Property

    Public ReadOnly Property FromLocation As ILocationStore Implements IRouteStore.FromLocation
        Get
            Return New LocationStore(connectionSource, connectionSource.ReadIntegerForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id), COLUMN_FROM_LOCATION_ID))
        End Get
    End Property

    Public ReadOnly Property ToLocation As ILocationStore Implements IRouteStore.ToLocation
        Get
            Return New LocationStore(connectionSource, connectionSource.ReadIntegerForValue(TABLE_ROUTES, (COLUMN_ROUTE_ID, Id), COLUMN_TO_LOCATION_ID))
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IRouteStore.Name
        Get
            Return Direction.Name
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IRouteStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property
End Class
