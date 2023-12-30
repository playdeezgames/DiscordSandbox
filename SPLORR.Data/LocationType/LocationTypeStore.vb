Imports Microsoft.Data.SqlClient

Friend Class LocationTypeStore
    Implements ILocationTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _locationTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._locationTypeId = locationTypeId
    End Sub

    Public ReadOnly Property Name As String Implements ILocationTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId), COLUMN_LOCATION_TYPE_NAME)
        End Get
    End Property

    Public ReadOnly Property Id As Integer Implements ILocationTypeStore.Id
        Get
            Return _locationTypeId
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements ILocationTypeStore.CanDelete
        Get
            Return Not _connectionSource.CheckForInteger(
                    TABLE_LOCATION_TYPE_VERB_TYPES,
                    (COLUMN_LOCATION_TYPE_ID, _locationTypeId)) AndAlso
                Not _connectionSource.CheckForInteger(
                    TABLE_LOCATIONS,
                    (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
        End Get
    End Property

    Public Sub Delete() Implements ILocationTypeStore.Delete
        _connectionSource.DeleteForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, _locationTypeId))
    End Sub
End Class
