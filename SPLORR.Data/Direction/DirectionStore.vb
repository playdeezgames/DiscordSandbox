Imports Microsoft.Data.SqlClient

Friend Class DirectionStore
    Implements IDirectionStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _directionId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), directionId As Integer)
        Me._connectionSource = connectionSource
        Me._directionId = directionId
    End Sub

    Public ReadOnly Property Name As String Implements IDirectionStore.Name
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {FIELD_DIRECTION_NAME} 
FROM 
    {TABLE_DIRECTIONS} 
WHERE 
    {FIELD_DIRECTION_ID}={PARAMETER_DIRECTION_ID};"
                command.Parameters.AddWithValue(PARAMETER_DIRECTION_ID, _directionId)
                Return CStr(command.ExecuteScalar)
            End Using
        End Get
    End Property
End Class
