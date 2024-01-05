Imports Microsoft.Data.SqlClient

Friend Class ItemTypeStore
    Implements IItemTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _itemTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._itemTypeId = itemTypeId
    End Sub

    Public ReadOnly Property Id As Integer Implements IItemTypeStore.Id
        Get
            Return _itemTypeId
        End Get
    End Property

    Public Property Name As String Implements IItemTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(
                TABLE_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_ID, _itemTypeId),
                COLUMN_ITEM_TYPE_NAME)
        End Get
        Set(value As String)
            _connectionSource.WriteStringForInteger(
                TABLE_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_ID, _itemTypeId),
                (COLUMN_ITEM_TYPE_NAME, value))
        End Set
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IItemTypeStore.CanDelete
        Get
            Return Not _connectionSource.CheckForInteger(TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES, (COLUMN_ITEM_TYPE_ID, _itemTypeId))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IItemTypeStore.Store
        Get
            Return New DataStore(_connectionSource())
        End Get
    End Property

    Public Sub Delete() Implements IItemTypeStore.Delete
        _connectionSource.DeleteForInteger(
            TABLE_ITEM_TYPES,
            (COLUMN_ITEM_TYPE_ID, _itemTypeId))
    End Sub

    Public Function CanRenameTo(newName As String) As Boolean Implements IItemTypeStore.CanRenameTo
        Return Not _connectionSource.FindIntegerForString(
            TABLE_ITEM_TYPES,
            (COLUMN_ITEM_TYPE_NAME, newName),
            COLUMN_ITEM_TYPE_ID).HasValue
    End Function
End Class
