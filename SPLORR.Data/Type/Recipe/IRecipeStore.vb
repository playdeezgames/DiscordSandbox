Public Interface IRecipeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property ItemTypes As IRelatedTypeStore(Of IRecipeItemTypeStore)
    ReadOnly Property CanAddItemType As Boolean
    ReadOnly Property AvailableItemTypes As IRelatedTypeStore(Of IItemTypeStore)
    Function CreateRecipeItemType(itemType As IItemTypeStore, quantityIn As Integer, quantityOut As Integer) As IRecipeItemTypeStore
    ReadOnly Property Inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore))
    ReadOnly Property Outputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore))
End Interface
