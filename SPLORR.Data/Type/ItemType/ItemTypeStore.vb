Imports Microsoft.Data.SqlClient

Friend Class ItemTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements IItemTypeStore


    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeId As Integer)
        MyBase.New(
            connectionSource,
            itemTypeId,
            TABLE_ITEM_TYPES,
            COLUMN_ITEM_TYPE_ID,
            COLUMN_ITEM_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValues(TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES, (COLUMN_ITEM_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateItem(inventoryStore As IInventoryStore) As IItemStore Implements IItemTypeStore.CreateItem
        Return New ItemStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_ITEMS,
                (COLUMN_ITEM_TYPE_ID, Id),
                (COLUMN_INVENTORY_ID, inventoryStore.Id)))
    End Function
End Class
