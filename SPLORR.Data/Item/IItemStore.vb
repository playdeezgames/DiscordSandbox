Public Interface IItemStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property Inventory As IInventoryStore
    Property ItemType As IItemTypeStore
End Interface
