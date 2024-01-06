Imports SPLORR.Data

Public Interface IInventoryModel
    Sub Add(item As IItemModel)
    ReadOnly Property InventoryStore As IInventoryStore
End Interface
