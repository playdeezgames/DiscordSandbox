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
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"SELECT {FIELD_LOCATION_NAME} FROM {TABLE_LOCATIONS} WHERE {FIELD_LOCATION_ID}={PARAMETER_LOCATION_ID};"
                command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, _locationId)
                Return CStr(command.ExecuteScalar)
            End Using
        End Get
    End Property
End Class
