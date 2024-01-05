Imports Microsoft.Data.SqlClient

Friend Class DirectionStore
    Implements IDirectionStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _directionId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), directionId As Integer)
        Me._connectionSource = connectionSource
        Me._directionId = directionId
    End Sub

    Public Property Name As String Implements IDirectionStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(
                TABLE_DIRECTIONS,
                (COLUMN_DIRECTION_ID, _directionId),
                COLUMN_DIRECTION_NAME)
        End Get
        Set(value As String)
            _connectionSource.WriteStringForInteger(TABLE_DIRECTIONS, (COLUMN_DIRECTION_ID, _directionId), (COLUMN_DIRECTION_NAME, value))
        End Set
    End Property

    Public ReadOnly Property Id As Integer Implements IDirectionStore.Id
        Get
            Return _directionId
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IDirectionStore.CanDelete
        Get
            Return Not _connectionSource.CheckForInteger(TABLE_ROUTES, (COLUMN_DIRECTION_ID, _directionId))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IDirectionStore.Store
        Get
            Return New DataStore(_connectionSource())
        End Get
    End Property

    Public Sub Delete() Implements IDirectionStore.Delete
        _connectionSource.DeleteForInteger(TABLE_DIRECTIONS, (COLUMN_DIRECTION_ID, _directionId))
    End Sub

    Public Function CanRenameTo(x As String) As Boolean Implements IDirectionStore.CanRenameTo
        Return Not _connectionSource.FindIntegerForString(
            TABLE_DIRECTIONS,
            (COLUMN_DIRECTION_NAME, x),
            COLUMN_DIRECTION_ID).HasValue
    End Function
End Class
