Imports Microsoft.Data.SqlClient

Friend Class ItemTypeStore
    Inherits BaseTypeStore
    Implements IItemTypeStore


    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeId As Integer)
        MyBase.New(
            connectionSource,
            itemTypeId,
            TABLE_ITEM_TYPES,
            COLUMN_ITEM_TYPE_ID,
            COLUMN_ITEM_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValue(TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES, (COLUMN_ITEM_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateItem(inventoryStore As IInventoryStore) As IItemStore Implements IItemTypeStore.CreateItem
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_ITEMS}
    (
        {COLUMN_ITEM_TYPE_ID},
        {COLUMN_INVENTORY_ID}
    )
    VALUES
    (
        {PARAMETER_ITEM_TYPE_ID},
        {PARAMETER_INVENTORY_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_INVENTORY_ID, inventoryStore.Id)
            command.ExecuteNonQuery()
        End Using
        Return New ItemStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function
End Class
