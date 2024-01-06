Public Interface IItemTypeStore
    Inherits IBaseTypeStore

    Function CreateItem(inventoryStore As IInventoryStore) As IItemStore
End Interface
