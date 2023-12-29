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
            Return _connectionSource.ReadStringForInteger(
                TABLE_DIRECTIONS,
                (FIELD_DIRECTION_ID, _directionId),
                FIELD_DIRECTION_NAME)
        End Get
    End Property
End Class
