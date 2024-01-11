Imports Microsoft.Data.SqlClient

Friend Class ItemStore
    Implements IItemStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IItemStore.Id

    Public Sub New(connectionSource As Func(Of SqlConnection), itemId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = itemId
    End Sub

    Public ReadOnly Property Name As String Implements IItemStore.Name
        Get
            Return connectionSource.ReadStringForValue(
                VIEW_ITEM_DETAILS,
                (COLUMN_ITEM_ID, Id),
                COLUMN_ITEM_NAME)
        End Get
    End Property

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
End Class
