Imports Microsoft.Data.SqlClient

Friend Class ItemStore
    Inherits BaseTypeStore
    Implements IItemStore

    Public Sub New(connectionSource As Func(Of SqlConnection), itemId As Integer)
        MyBase.New(
            connectionSource,
            itemId,
            VIEW_ITEM_DETAILS,
            COLUMN_ITEM_ID,
            COLUMN_ITEM_NAME,
            TABLE_ITEMS)
    End Sub

    Public Property Inventory As IInventoryStore Implements IItemStore.Inventory
        Get
            Return New InventoryStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_ITEMS,
                    (COLUMN_ITEM_ID, Id),
                    COLUMN_INVENTORY_ID))
        End Get
        Set(value As IInventoryStore)
            connectionSource.WriteValueForInteger(
                TABLE_ITEMS,
                (COLUMN_ITEM_ID, Id),
                (COLUMN_INVENTORY_ID, value.Id))
        End Set
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property ItemType As IItemTypeStore Implements IItemStore.ItemType
        Get
            Return New ItemTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_ITEMS,
                    (COLUMN_ITEM_ID, Id),
                    COLUMN_ITEM_TYPE_ID))
        End Get
        Set(value As IItemTypeStore)
            connectionSource.WriteValueForInteger(
                TABLE_ITEMS,
                (COLUMN_ITEM_ID, Id),
                (COLUMN_ITEM_TYPE_ID, value.Id))
        End Set
    End Property
End Class
