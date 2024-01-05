Imports Microsoft.Data.SqlClient

Friend Class LocationTypeStore
    Inherits BaseTypeStore
    Implements ILocationTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _locationTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._locationTypeId = locationTypeId
    End Sub

    Public Overrides Property Name As String
        Get
            Return _connectionSource.ReadStringForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), COLUMN_LOCATION_TYPE_NAME)
        End Get
        Set(value As String)
            _connectionSource.WriteStringForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), (COLUMN_LOCATION_TYPE_NAME, value))
        End Set
    End Property

    Public Overrides ReadOnly Property Id As Integer
        Get
            Return _locationTypeId
        End Get
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
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
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {VIEW_LOCATION_TYPE_AVAILABLE_VERB_TYPES} 
WHERE 
    {COLUMN_LOCATION_TYPE_ID}={PARAMETER_LOCATION_TYPE_ID} 
    AND {COLUMN_LOCATION_TYPE_VERB_TYPE_ID} IS NULL;"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property AvailableVerbTypes As IEnumerable(Of IVerbTypeStore) Implements ILocationTypeStore.AvailableVerbTypes
        Get
            Dim result As New List(Of IVerbTypeStore)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_VERB_TYPE_ID} 
FROM 
    {VIEW_LOCATION_TYPE_AVAILABLE_VERB_TYPES} 
WHERE 
    {COLUMN_LOCATION_TYPE_ID}={PARAMETER_LOCATION_TYPE_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add(New VerbTypeStore(_connectionSource, reader.GetInt32(0)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public ReadOnly Property VerbTypes As IEnumerable(Of IVerbTypeStore) Implements ILocationTypeStore.VerbTypes
        Get
            Dim result As New List(Of IVerbTypeStore)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_VERB_TYPE_ID} 
FROM 
    {TABLE_LOCATION_TYPE_VERB_TYPES} 
WHERE 
    {COLUMN_LOCATION_TYPE_ID}={PARAMETER_LOCATION_TYPE_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add(New VerbTypeStore(_connectionSource, reader.GetInt32(0)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public Overrides ReadOnly Property Store As IDataStore
        Get
            Return New DataStore(_connectionSource())
        End Get
    End Property

    Public Overrides Sub Delete()
        _connectionSource.DeleteForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
    End Sub

    Public Sub AddVerb(verbTypeStore As IVerbTypeStore) Implements ILocationTypeStore.AddVerb
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_LOCATION_TYPE_VERB_TYPES}
    (
        {COLUMN_LOCATION_TYPE_ID},
        {COLUMN_VERB_TYPE_ID}
    ) 
    VALUES 
    (
        {PARAMETER_LOCATION_TYPE_ID},
        {PARAMETER_VERB_TYPE_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, _locationTypeId)
            command.Parameters.AddWithValue(PARAMETER_VERB_TYPE_ID, verbTypeStore.Id)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub RemoveVerb(verbTypeStore As IVerbTypeStore) Implements ILocationTypeStore.RemoveVerb
        _connectionSource.DeleteForIntegers(TABLE_LOCATION_TYPE_VERB_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), (COLUMN_VERB_TYPE_ID, verbTypeStore.Id))
    End Sub

    Public Overrides Function CanRenameTo(newName As String) As Boolean
        Return Not _connectionSource.FindIntegerForString(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_NAME, newName), COLUMN_LOCATION_TYPE_ID).HasValue
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
