Imports Microsoft.Data.SqlClient

Friend Class InventoryStore
    Implements IInventoryStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IInventoryStore.Id

    Public ReadOnly Property HasItems As Boolean Implements IInventoryStore.HasItems
        Get
            Return connectionSource.CheckForValue(TABLE_ITEMS, (COLUMN_INVENTORY_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItemStore) Implements IInventoryStore.Items
        Get
            Return connectionSource.ReadIntegersForValue(
                TABLE_ITEMS,
                (COLUMN_INVENTORY_ID, Id),
                COLUMN_ITEM_ID).Select(Function(x) New ItemStore(connectionSource, x))
        End Get
    End Property

    Public Sub New(connectionSource As Func(Of SqlConnection), inventoryId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = inventoryId
    End Sub
End Class
