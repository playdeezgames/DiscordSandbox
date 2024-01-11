Public Interface IItemTypeGeneratorStore
    Inherits IBaseTypeStore
    ReadOnly Property TotalWeight As Integer
    ReadOnly Property HasItemTypes As Boolean
    ReadOnly Property CanAddItemType As Boolean
    Function Generate(generated As Integer) As IItemTypeStore
    Function AddItemType(itemType As IItemTypeStore, quantity As Integer) As IItemTypeGeneratorItemTypeStore
    ReadOnly Property ItemTypes As ITypeStore(Of IItemTypeGeneratorItemTypeStore)
    ReadOnly Property AvailableItemTypes As ITypeStore(Of IItemTypeStore)
    Property NothingGeneratorWeight As Integer
End Interface
