Imports Microsoft.Data.SqlClient

Friend Class VerbTypeStore
    Implements IVerbTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _verbTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), verbTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._verbTypeId = verbTypeId
    End Sub

    Public ReadOnly Property Id As Integer Implements IVerbTypeStore.Id
        Get
            Return _verbTypeId
        End Get
    End Property

    Public Property Name As String Implements IVerbTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId), COLUMN_VERB_TYPE_NAME)
        End Get
        Set(value As String)
            _connectionSource.WriteStringForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId), (COLUMN_VERB_TYPE_NAME, value))
        End Set
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IVerbTypeStore.CanDelete
        Get
            Return Not HasLocationTypes
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IVerbTypeStore.Store
        Get
            Return New DataStore(_connectionSource())
        End Get
    End Property

    Private ReadOnly Property HasLocationTypes As Boolean
        Get
            Return _connectionSource.CheckForInteger(TABLE_LOCATION_TYPE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId))
        End Get
    End Property

    Public Sub Delete() Implements IVerbTypeStore.Delete
        _connectionSource.DeleteForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId))
    End Sub

    Public Function CanRenameTo(newName As String) As Boolean Implements IVerbTypeStore.CanRenameTo
        Return Not _connectionSource.FindIntegerForString(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_NAME, newName), COLUMN_VERB_TYPE_ID).HasValue
    End Function
End Class
