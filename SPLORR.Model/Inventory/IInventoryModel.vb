Imports SPLORR.Data

Public Interface IInventoryModel
    Sub Add(item As IItemModel)
    ReadOnly Property InventoryStore As IInventoryStore
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItemModel)
End Interface
