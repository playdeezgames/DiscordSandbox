Public Interface IRecipeStore
    Inherits IBaseTypeStore
    ReadOnly Property ItemTypes As IRelatedTypeStore(Of IRecipeItemTypeStore)
    ReadOnly Property CanAddItemType As Boolean
    ReadOnly Property AvailableItemTypes As IRelatedTypeStore(Of IItemTypeStore)
    Function CreateRecipeItemType(itemType As IItemTypeStore, quantityIn As Integer, quantityOut As Integer) As IRecipeItemTypeStore
End Interface
