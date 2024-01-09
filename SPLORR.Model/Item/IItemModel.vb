Imports SPLORR.Data

Public Interface IItemModel
    ReadOnly Property Name As String
    ReadOnly Property ItemStore As IItemStore
    Property Inventory As IInventoryModel
End Interface
