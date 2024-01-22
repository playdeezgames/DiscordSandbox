Imports Microsoft.Data.SqlClient

Friend Class LocationTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ILocationTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), locationTypeId As Integer)
        MyBase.New(
            connectionSource,
            locationTypeId,
            TABLE_LOCATION_TYPES,
            COLUMN_LOCATION_TYPE_ID,
            COLUMN_LOCATION_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasLocations
        End Get
    End Property

    Public ReadOnly Property HasLocations As Boolean Implements ILocationTypeStore.HasLocations
        Get
            Return connectionSource.CheckForValues(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_TYPE_ID, Id))
        End Get
    End Property

    Public Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore) Implements ILocationTypeStore.FilterLocations
        Return connectionSource.ReadIntegersForValues(
            TABLE_LOCATIONS,
            {(COLUMN_LOCATION_TYPE_ID, Id)},
            {(COLUMN_LOCATION_NAME, filter)},
            COLUMN_LOCATION_ID).Select(Function(x) New LocationStore(connectionSource, x))
    End Function

    Public Function CreateLocation(name As String) As ILocationStore Implements ILocationTypeStore.CreateLocation
        Return New LocationStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_NAME, name),
                (COLUMN_LOCATION_TYPE_ID, Id)))
    End Function
End Class
