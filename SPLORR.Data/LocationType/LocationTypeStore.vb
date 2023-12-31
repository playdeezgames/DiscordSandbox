Imports Microsoft.Data.SqlClient

Friend Class LocationTypeStore
    Implements ILocationTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _locationTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._locationTypeId = locationTypeId
    End Sub

    Public Property Name As String Implements ILocationTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), COLUMN_LOCATION_TYPE_NAME)
        End Get
        Set(value As String)
            _connectionSource.WriteStringForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), (COLUMN_LOCATION_TYPE_NAME, value))
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements ILocationTypeStore.Id
        Get
            Return _locationTypeId
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements ILocationTypeStore.CanDelete
        Get
            Return Not HasVerbs AndAlso
                Not HasLocations
        End Get
    End Property

    Public ReadOnly Property HasLocations As Boolean Implements ILocationTypeStore.HasLocations
        Get
            Return _connectionSource.CheckForInteger(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
        End Get
    End Property

    Public ReadOnly Property HasVerbs As Boolean Implements ILocationTypeStore.HasVerbs
        Get
            Return _connectionSource.CheckForInteger(
                            TABLE_LOCATION_TYPE_VERB_TYPES,
                            (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
        End Get
    End Property

    Public ReadOnly Property CanAddVerb As Boolean Implements ILocationTypeStore.CanAddVerb
        Get
            Return _connectionSource.CheckForInteger(
                VIEW_LOCATION_TYPE_AVAILABLE_VERB_TYPES,
                (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
        End Get
    End Property

    Public Sub Delete() Implements ILocationTypeStore.Delete
        _connectionSource.DeleteForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
    End Sub

    Public Function CanRenameTo(name As String) As Boolean Implements ILocationTypeStore.CanRenameTo
        Return Not _connectionSource.FindIntegerForString(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_NAME, name), COLUMN_LOCATION_TYPE_ID).HasValue
    End Function

    Public Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore) Implements ILocationTypeStore.FilterLocations
        Dim result As New List(Of ILocationStore)
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_LOCATION_ID} 
FROM 
    {TABLE_LOCATIONS} 
WHERE 
    {COLUMN_LOCATION_ID}={PARAMETER_LOCATION_TYPE_ID} 
    AND {COLUMN_LOCATION_NAME} LIKE {PARAMETER_LOCATION_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_NAME, filter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(New LocationStore(_connectionSource, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function FilterVerbTypes(filter As String) As IEnumerable(Of IVerbTypeStore) Implements ILocationTypeStore.FilterVerbTypes
        Dim result As New List(Of IVerbTypeStore)
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    ltvt.{COLUMN_VERB_TYPE_ID} 
FROM 
    {TABLE_LOCATION_TYPE_VERB_TYPES} ltvt
    JOIN {TABLE_VERB_TYPES} vt ON ltvt.{COLUMN_VERB_TYPE_ID}=vt.{COLUMN_VERB_TYPE_ID}
WHERE 
    ltvt.{COLUMN_LOCATION_TYPE_ID}={PARAMETER_LOCATION_TYPE_ID}
    AND vt.{COLUMN_VERB_TYPE_NAME} LIKE {PARAMETER_VERB_TYPE_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
            command.Parameters.AddWithValue(PARAMETER_VERB_TYPE_NAME, filter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(New VerbTypeStore(_connectionSource, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function
End Class
