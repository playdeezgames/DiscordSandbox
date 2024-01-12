Public Interface IRecipeItemTypeStore
    ReadOnly Property Id As Integer
    ReadOnly Property ItemType As IItemTypeStore
    ReadOnly Property QuantityIn As Integer
    ReadOnly Property QuantityOut As Integer
    ReadOnly Property Recipe As IRecipeStore
    Sub Delete()
End Interface
