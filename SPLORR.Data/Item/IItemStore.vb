Public Interface IItemStore
    ReadOnly Property Id As Integer
    ReadOnly Property Name As String
    Property Inventory As IInventoryStore
End Interface
