Imports Microsoft.Data.SqlClient

Friend Class DirectionStore
    Inherits BaseTypeStore
    Implements IDirectionStore

    Public Sub New(connectionSource As Func(Of SqlConnection), directionId As Integer)
        MyBase.New(
            connectionSource,
            directionId,
            TABLE_DIRECTIONS,
            COLUMN_DIRECTION_ID,
            COLUMN_DIRECTION_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForInteger(TABLE_ROUTES, (COLUMN_DIRECTION_ID, Id))
        End Get
    End Property

    Public Overrides Sub Delete()
        connectionSource.DeleteForInteger(TABLE_DIRECTIONS, (COLUMN_DIRECTION_ID, Id))
    End Sub

    Public Overrides Function CanRenameTo(x As String) As Boolean
        Return Not connectionSource.FindIntegerForString(
            TABLE_DIRECTIONS,
            (COLUMN_DIRECTION_NAME, x),
            COLUMN_DIRECTION_ID).HasValue
    End Function
End Class
