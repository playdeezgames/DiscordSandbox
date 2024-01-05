Imports Microsoft.Data.SqlClient

Friend Class ItemTypeStore
    Inherits BaseTypeStore
    Implements IItemTypeStore

    Private ReadOnly _itemTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeId As Integer)
        MyBase.New(connectionSource)
        Me._itemTypeId = itemTypeId
    End Sub

    Public Overrides ReadOnly Property Id As Integer
        Get
            Return _itemTypeId
        End Get
    End Property

    Public Overrides Property Name As String
        Get
            Return connectionSource.ReadStringForInteger(
                TABLE_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_ID, _itemTypeId),
                COLUMN_ITEM_TYPE_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteStringForInteger(
                TABLE_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_ID, _itemTypeId),
                (COLUMN_ITEM_TYPE_NAME, value))
        End Set
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForInteger(TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES, (COLUMN_ITEM_TYPE_ID, _itemTypeId))
        End Get
    End Property

    Public Overrides Sub Delete()
        connectionSource.DeleteForInteger(
            TABLE_ITEM_TYPES,
            (COLUMN_ITEM_TYPE_ID, _itemTypeId))
    End Sub

    Public Overrides Function CanRenameTo(newName As String) As Boolean
        Return Not connectionSource.FindIntegerForString(
            TABLE_ITEM_TYPES,
            (COLUMN_ITEM_TYPE_NAME, newName),
            COLUMN_ITEM_TYPE_ID).HasValue
    End Function
End Class
