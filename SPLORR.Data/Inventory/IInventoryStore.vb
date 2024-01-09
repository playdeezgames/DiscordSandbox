Public Interface IInventoryStore
    ReadOnly Property Id As Integer
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItemStore)
End Interface
