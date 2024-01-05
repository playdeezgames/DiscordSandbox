Imports Microsoft.Data.SqlClient

Friend Class DirectionStore
    Inherits BaseTypeStore
    Implements IDirectionStore

    Private ReadOnly _directionId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), directionId As Integer)
        MyBase.New(connectionSource)
        Me._directionId = directionId
    End Sub

    Public Overrides Property Name As String
        Get
            Return connectionSource.ReadStringForInteger(
                TABLE_DIRECTIONS,
                (COLUMN_DIRECTION_ID, _directionId),
                COLUMN_DIRECTION_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteStringForInteger(TABLE_DIRECTIONS, (COLUMN_DIRECTION_ID, _directionId), (COLUMN_DIRECTION_NAME, value))
        End Set
    End Property

    Public Overrides ReadOnly Property Id As Integer
        Get
            Return _directionId
        End Get
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForInteger(TABLE_ROUTES, (COLUMN_DIRECTION_ID, _directionId))
        End Get
    End Property

    Public Overrides Sub Delete()
        connectionSource.DeleteForInteger(TABLE_DIRECTIONS, (COLUMN_DIRECTION_ID, _directionId))
    End Sub

    Public Overrides Function CanRenameTo(x As String) As Boolean
        Return Not connectionSource.FindIntegerForString(
            TABLE_DIRECTIONS,
            (COLUMN_DIRECTION_NAME, x),
            COLUMN_DIRECTION_ID).HasValue
    End Function
End Class
